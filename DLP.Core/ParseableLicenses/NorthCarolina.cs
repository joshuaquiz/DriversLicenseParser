﻿using DLP.Core.Interfaces;
using DLP.Core.Models;

namespace DLP.Core.ParseableLicenses
{
    public sealed class NorthCarolina : IParseableLicense
    {
        public string FullName => "North Carolina";

        public string Abbreviation => "NC";

        public string Country => "USA";

        public int IssuerIdentificationNumber => 636004;

        public bool IsDataFromEntity(string data) =>
            data.Contains(IssuerIdentificationNumber.ToString());

        public DriversLicenseData ParseData(string data)
        {
            return null;
        }
    }
}