﻿using System.Collections.Generic;
using Yoti.Auth.Anchors;
using static Yoti.Auth.YotiAttributeValue;

namespace Yoti.Auth
{
    public class YotiImageAttribute<T> : YotiAttribute<T> where T : Image
    {
        public YotiImageAttribute(string name, YotiAttributeValue value) : base(name, value)
        {
        }

        public YotiImageAttribute(string name, YotiAttributeValue value, List<Anchor> anchors) : base(name, value, anchors)
        {
        }

        public Image GetImage()
        {
            return new Image
            {
                Base64URI = GetBase64URI(),
                Data = Value.ToBytes(),
                Type = Value.Type
            };
        }

        public string GetBase64URI()
        {
            switch (Value.Type)

            {
                case TypeEnum.Jpeg:
                    return "data:image/jpeg;base64," + Conversion.BytesToBase64(Value.ToBytes());
                case TypeEnum.Png:
                    return "data:image/png;base64," + Conversion.BytesToBase64(Value.ToBytes());
                default:
                    return null;
            }
        }
    }
}