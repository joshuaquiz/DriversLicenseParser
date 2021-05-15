﻿using DLP.Core.Models;

namespace DLP.Core.Parsers
{
    public sealed class Maryland : IParseable
    {
        public string FullName => "Maryland";

        public string Abbreviation => "MD";

        public string Country => "USA";

        public int IssuerIdentificationNumber => 636003;

        public bool IsDataFromEntity(string data) =>
            data.Contains(IssuerIdentificationNumber.ToString());

        public DriversLicenseData ParseData(string data)
        {
            return null;
        }
    }
}