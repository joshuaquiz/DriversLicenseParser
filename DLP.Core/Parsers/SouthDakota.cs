﻿using DLP.Core.Models;

namespace DLP.Core.Parsers
{
    public sealed class SouthDakota : IParseable
    {
        public string FullName => "South Dakota";

        public string Abbreviation => "SD";

        public string Country => "USA";

        public int IssuerIdentificationNumber => 636042;

        public bool IsDataFromEntity(string data) =>
            data.Contains(IssuerIdentificationNumber.ToString());

        public DriversLicenseData ParseData(string data)
        {
            return null;
        }
    }
}