using System;
using System.Text.RegularExpressions;
using DLP.Core.Interfaces;
using DLP.Core.Models;
using DLP.Core.Models.Enums;
using Serilog;

namespace DLP.Core.Parsers
{

    public sealed class Alabama : IParseableLicense
    {
        public string FullName => "Alabama";

        public string Abbreviation => "AL";

        public string Country => "USA";

        public int IssuerIdentificationNumber => 636033;

        public bool IsDataFromEntity(string data) =>
            data.Contains(IssuerIdentificationNumber.ToString());

        public DriversLicenseData ParseData(string data)
        {
            return null;
        }
    }

}