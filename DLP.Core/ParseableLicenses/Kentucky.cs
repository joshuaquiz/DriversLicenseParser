﻿using DLP.Core.Interfaces;
using DLP.Core.Models;

namespace DLP.Core.ParseableLicenses
{
    public sealed class Kentucky : IParseableLicense
    {
        public string FullName => "Kentucky";

        public string Abbreviation => "KY";

        public string Country => "USA";

        public int IssuerIdentificationNumber => 636046;

        public bool IsDataFromEntity(string data) =>
            data.Contains(IssuerIdentificationNumber.ToString());

        public DriversLicenseData ParseData(string data)
        {
            return null;
        }
    }
}