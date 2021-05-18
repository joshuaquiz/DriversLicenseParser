﻿using DLP.Core.Interfaces;
using DLP.Core.Models;

namespace DLP.Core.ParseableLicenses
{
    public sealed class NorthernMariannaIslands : IParseableLicense
    {
        public string FullName => "Northern Marianna Islands";

        public string Abbreviation => "MP";

        public string Country => "USA";

        public int IssuerIdentificationNumber => 604430;

        public bool IsDataFromEntity(string data) =>
            data.Contains(IssuerIdentificationNumber.ToString());

        public DriversLicenseData ParseData(string data)
        {
            return null;
        }
    }
}