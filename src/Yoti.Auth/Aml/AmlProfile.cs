﻿using Newtonsoft.Json;

namespace Yoti.Auth.Aml
{
    public class AmlProfile : IAmlProfile
    {
        [JsonRequired]
        [JsonProperty(PropertyName = "given_names")]
        private string _givenNames;

        [JsonRequired]
        [JsonProperty(PropertyName = "family_name")]
        private string _familyName;

        [JsonProperty(PropertyName = "ssn")]
        private string _ssn;

        [JsonRequired]
        [JsonProperty(PropertyName = "address")]
        private AmlAddress _amlAddress;

        public AmlProfile(string givenNames, string familyName, AmlAddress amlAddress, string ssn = null)
        {
            _givenNames = givenNames;
            _familyName = familyName;
            _ssn = ssn;
            _amlAddress = amlAddress;
        }

        public IAmlAddress GetAmlAddress()
        {
            return _amlAddress;
        }

        public string GetFamilyName()
        {
            return _familyName;
        }

        public string GetGivenNames()
        {
            return _givenNames;
        }

        public string GetSsn()
        {
            return _ssn;
        }
    }
}