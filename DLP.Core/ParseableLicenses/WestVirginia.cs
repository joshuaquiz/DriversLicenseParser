﻿using DLP.Core.Interfaces;
using DLP.Core.Models;

namespace DLP.Core.ParseableLicenses
{
    public sealed class WestVirginia : IParseableLicense
    {
        public string FullName => "West Virginia";

        public string Abbreviation => "WV";

        public string Country => "USA";

        public int IssuerIdentificationNumber => 636061;

        public bool IsDataFromEntity(string data) =>
            data.Contains(IssuerIdentificationNumber.ToString());

        public DriversLicenseData ParseData(string data)
        {
            return null;
        }
    }
}