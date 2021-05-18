﻿using DLP.Core.Interfaces;
using DLP.Core.Models;

namespace DLP.Core.ParseableLicenses
{
    public sealed class DistrictOfColumbia : IParseableLicense
    {
        public string FullName => "District of Columbia";

        public string Abbreviation => "DC";

        public string Country => "USA";

        public int IssuerIdentificationNumber => 636043;

        public bool IsDataFromEntity(string data) =>
            data.Contains(IssuerIdentificationNumber.ToString());

        public DriversLicenseData ParseData(string data)
        {
            return null;
        }
    }
}