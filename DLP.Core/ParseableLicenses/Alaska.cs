﻿using DLP.Core.Interfaces;
using DLP.Core.Models;

namespace DLP.Core.ParseableLicenses
{
    public sealed class Alaska : IParseableLicense
    {
        public string FullName => "Alaska";

        public string Abbreviation => "AK";

        public string Country => "USA";

        public int IssuerIdentificationNumber => 636059;

        public bool IsDataFromEntity(string data) =>
            data.Contains(IssuerIdentificationNumber.ToString());

        public DriversLicenseData ParseData(string data)
        {
            return null;
        }
    }
}