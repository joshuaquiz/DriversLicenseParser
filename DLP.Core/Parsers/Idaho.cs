﻿using DLP.Core.Models;

namespace DLP.Core.Parsers
{
    public sealed class Idaho : IParseable
    {
        public string FullName => "Idaho";

        public string Abbreviation => "ID";

        public string Country => "USA";

        public int IssuerIdentificationNumber => 636050;

        public bool IsDataFromEntity(string data) =>
            data.Contains(IssuerIdentificationNumber.ToString());

        public DriversLicenseData ParseData(string data)
        {
            return null;
        }
    }
}