﻿using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json.Linq;

namespace Yoti.Auth
{
    public class YotiAttributeValue
    {
        public enum TypeEnum { Text, Date, Jpeg, Png, Json, Bool }

        private readonly TypeEnum _type;
        private readonly byte[] _data;

        public YotiAttributeValue(TypeEnum type, byte[] data)
        {
            _type = type;
            _data = data;
        }

        public YotiAttributeValue(TypeEnum type, string data)
        {
            _type = type;

            switch (_type)
            {
                case TypeEnum.Jpeg:
                case TypeEnum.Png:
                    _data = Conversion.Base64ToBytes(data);
                    break;

                default:
                    _data = Conversion.UtfToBytes(data);
                    break;
            }
        }

        public TypeEnum Type
        {
            get
            {
                return _type;
            }
        }

        public byte[] ToBytes()
        {
            return _data;
        }

        public override string ToString()
        {
            return Conversion.BytesToUtf8(_data);
        }

        public DateTime? ToDate()
        {
            switch (_type)
            {
                case TypeEnum.Date:
                    DateTime date;
                    if (DateTime.TryParseExact(ToString(), "yyyy-MM-dd", CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out date))
                    {
                        return date;
                    }
                    else
                    {
                        return null;
                    }
                default:
                    return null;
            }
        }

        public Dictionary<string, JToken> ToJson()
        {
            string utf8json = Conversion.BytesToUtf8(_data);
            Dictionary<string, JToken> deserializedJson = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, JToken>>(utf8json);
            return deserializedJson;
        }
    }
}