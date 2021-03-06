﻿using System;
using System.IO;
using AttrpubapiV1;
using CompubapiV1;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Encodings;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Modes;
using Org.BouncyCastle.Crypto.Paddings;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.OpenSsl;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.X509;

namespace Yoti.Auth
{
    internal static class CryptoEngine
    {
        private const string DigestAlgorithm = "SHA-256withRSA";

        public static AsymmetricCipherKeyPair LoadRsaKey(StreamReader keyStream)
        {
            var pemReader = new PemReader(keyStream);
            return (AsymmetricCipherKeyPair)pemReader.ReadObject();
        }

        public static byte[] DecipherAes(byte[] key, byte[] iv, byte[] cipherBytes)
        {
            KeyParameter keyParam = new KeyParameter(key);
            ParametersWithIV keyParamWithIv = new ParametersWithIV(keyParam, iv);

            // decrypt using aes with private key and PKCS5/PKCS7
            AesEngine engine = new AesEngine();
            CbcBlockCipher blockCipher = new CbcBlockCipher(engine);
            PaddedBufferedBlockCipher paddedBlockCipher = new PaddedBufferedBlockCipher(blockCipher); //Default scheme is PKCS5/PKCS7
            byte[] outputBuffer = new byte[paddedBlockCipher.GetOutputSize(cipherBytes.Length)];

            paddedBlockCipher.Init(false, keyParamWithIv);
            int numOutputBytes = paddedBlockCipher.ProcessBytes(cipherBytes, outputBuffer, 0);
            numOutputBytes += paddedBlockCipher.DoFinal(outputBuffer, numOutputBytes);

            byte[] result = new byte[numOutputBytes];
            Array.Copy(outputBuffer, result, numOutputBytes);

            return result;
        }

        public static byte[] DecryptRsa(byte[] cipherBytes, AsymmetricCipherKeyPair keypair)
        {
            // decrypt using rsa with private key and PKCS 1 v1.5 padding
            RsaEngine engine = new RsaEngine();
            Pkcs1Encoding blockCipher = new Pkcs1Encoding(engine);

            blockCipher.Init(false, keypair.Private);
            return blockCipher.ProcessBlock(cipherBytes, 0, cipherBytes.Length);
        }

        public static byte[] SignDigest(byte[] digestBytes, AsymmetricCipherKeyPair keypair)
        {
            // create a signature from the digest using SHA256 hashing with RSA
            var signer = SignerUtilities.GetSigner(DigestAlgorithm);
            signer.Init(true, keypair.Private);
            signer.BlockUpdate(digestBytes, 0, digestBytes.Length);
            return signer.GenerateSignature();
        }

        public static byte[] GetDerEncodedPublicKey(AsymmetricCipherKeyPair keypair)
        {
            return SubjectPublicKeyInfoFactory.CreateSubjectPublicKeyInfo(keypair.Public).GetDerEncoded();
        }

        public static string GenerateNonce()
        {
            SecureRandom random = new SecureRandom();

            byte[] bytes = new byte[16];
            random.NextBytes(bytes);

            return new Guid(bytes).ToString("D");
        }

        public static string DecryptToken(string encryptedConnectToken, AsymmetricCipherKeyPair keyPair)
        {
            // token was encoded as a urlsafe base64 so it can be transfered in a url
            byte[] cipherBytes = Conversion.UrlSafeBase64ToBytes(encryptedConnectToken);

            byte[] decipheredBytes = DecryptRsa(cipherBytes, keyPair);

            return Conversion.BytesToUtf8(decipheredBytes);
        }

        public static byte[] UnwrapKey(string wrappedKey, AsymmetricCipherKeyPair keyPair)
        {
            byte[] cipherBytes = Conversion.Base64ToBytes(wrappedKey);

            return DecryptRsa(cipherBytes, keyPair);
        }

        public static AttributeList DecryptCurrentUserReceipt(string wrappedReceiptKey, string otherPartyProfile, AsymmetricCipherKeyPair keyPair)
        {
            byte[] unwrappedKey = UnwrapKey(wrappedReceiptKey, keyPair);

            byte[] otherPartyProfileContentBytes = Conversion.Base64ToBytes(otherPartyProfile);
            EncryptedData encryptedData = EncryptedData.Parser.ParseFrom(otherPartyProfileContentBytes);

            byte[] iv = encryptedData.Iv.ToByteArray();
            byte[] cipherText = encryptedData.CipherText.ToByteArray();

            byte[] decipheredBytes = DecipherAes(unwrappedKey, iv, cipherText);

            return AttributeList.Parser.ParseFrom(decipheredBytes);
        }

        public static string GetAuthKey(AsymmetricCipherKeyPair keyPair)
        {
            byte[] publicKey = GetDerEncodedPublicKey(keyPair);

            return Conversion.BytesToBase64(publicKey);
        }
    }
}