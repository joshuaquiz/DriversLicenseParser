﻿using DLP.Core.Models;

namespace DLP.Core.Parsers
{
    public sealed class Manitoba : IParseable
    {
        public string FullName => "Manitoba";

        public string Abbreviation => "MB";

        public string Country => "CANADA";

        public int IssuerIdentificationNumber => 636048;

        public bool IsDataFromEntity(string data) =>
            data.Contains(IssuerIdentificationNumber.ToString());

        public DriversLicenseData ParseData(string data)
        {
            return null;
        }
    }
}