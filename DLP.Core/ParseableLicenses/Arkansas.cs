﻿using DLP.Core.Interfaces;
using DLP.Core.Models;

namespace DLP.Core.ParseableLicenses
{
    public sealed class Arkansas : IParseableLicense
    {
        public string FullName => "Arkansas";

        public string Abbreviation => "AR";

        public string Country => "USA";

        public int IssuerIdentificationNumber => 636021;

        public bool IsDataFromEntity(string data) =>
            data.Contains(IssuerIdentificationNumber.ToString());

        public DriversLicenseData ParseData(string data)
        {
            return null;
        }
    }
}