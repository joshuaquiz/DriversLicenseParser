﻿using DLP.Core.Interfaces;
using DLP.Core.Models;

namespace DLP.Core.ParseableLicenses
{
    public sealed class Quebec : IParseableLicense
    {
        public string FullName => "Quebec";

        public string Abbreviation => "QC";

        public string Country => "CANADA";

        public int IssuerIdentificationNumber => 604428;

        public bool IsDataFromEntity(string data) =>
            data.Contains(IssuerIdentificationNumber.ToString());

        public DriversLicenseData ParseData(string data)
        {
            return null;
        }
    }
}