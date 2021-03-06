﻿using System;
using System.Net.Http;

namespace Yoti.Auth
{
    internal class EndpointFactory
    {
        public static string CreateProfileEndpoint(HttpMethod httpMethod, string path, string token, string sdkId)
        {
            return string.Format(
                "/{0}/{1}?nonce={2}&timestamp={3}&appId={4}",
                path,
                token,
                CryptoEngine.GenerateNonce(),
                GetTimestamp(),
                sdkId);
        }

        public static string CreateAmlEndpoint(HttpMethod httpMethod, string appId)
        {
            return string.Format(
                "/aml-check?appId={0}&timestamp={1}&nonce={2}",
                appId,
                GetTimestamp(),
                CryptoEngine.GenerateNonce());
        }

        private static string GetTimestamp()
        {
            long milliseconds = (long)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalMilliseconds;

            return milliseconds.ToString();
        }
    }
}