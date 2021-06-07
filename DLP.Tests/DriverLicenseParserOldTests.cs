/*using System.Collections.Generic;
using System.Web;
using Xunit;

namespace DLP.Tests
{
    public class DriverLicenseParserOldTests
    {
        public static IEnumerable<object[]> GetDataSets() =>
            new List<object[]>
            {
                new object[]
                {
                    "%40%0A%1E%0DANSI%20636040030002DL00410223ZU02640008DLDCAD%0ADCBB%0ADCD%0ADBA10162017%0ADCSDOE%0ADCTJOHN%2CD%2C%0ADBD10152012%0ADBB10162010%0ADBC1%0ADAYBRO%0ADAU%2070%20in%0ADAG1234 FAKE AVE%0ADAISALT%20LAKE%20CITY%0ADAJUT%0ADAK84115%20%20%20%20%20%20%0ADAQ123456789%0ADCF0123456789_108425421%0ADCGUSA%0ADCHNONE%0ADAZBROWN%0A%0DZUZUAY%0A%0D&",
                    new CustomerShell
                    {
                        PrimaryFirstName = "JOHN",
                        PrimaryMiddleName = "D",
                        PrimaryLastName = "DOE",
                        PrimaryDOB = "10/16/2010",
                        Address1 = "1234 FAKE AVE",
                        Address2 = null,
                        City = "SALT LAKE CITY",
                        State = "UT",
                        Zip = "84115",
                        County = string.Empty,
                        DriversLicenseNumber = "123456789"
                    }
                },
                new object[]
                {
                    "OHMYCITY%5EDOE%24JOHN%24D%24%5E1234%20FAKE%20AVE%5E6360232017123456789%3D16122010122310452273804%20%20D%20A%20%20%20%20%20%20%20%20%20%20%20%20%202503130BROHAZ",
                    new CustomerShell
                    {
                        PrimaryFirstName = "JOHN",
                        PrimaryMiddleName = "D",
                        PrimaryLastName = "DOE",
                        PrimaryDOB = "12/23/2010",
                        Address1 = "1234 FAKE AVE",
                        Address2 = null,
                        City = "MYCITY",
                        State = "OH",
                        Zip = "45227-3804",
                        County = string.Empty,
                        DriversLicenseNumber = "123456789"
                    }
                },
                new object[]
                {
                    "%40%0A%1E%0DAAMVA36004001DL00280195DLDABDOE%0ADACJOHN%0ADADD%0ADAE%0ADAL1234%20FAKE%20CT%0ADAM%0ADANMYCITY%0ADAONC%0ADAP28451-7030%0ADAQ123456789%0ADARC%0ADASNone%0ADATNone%0ADAV5-10%0ADAYBLU%0ADAZBRO%0ADBA06-19-2023%0ADBB06-19-2010%0ADBCM%0ADBD06-22-2015%0ADBHY%0D&",
                    new CustomerShell
                    {
                        PrimaryFirstName = "JOHN",
                        PrimaryMiddleName = "D",
                        PrimaryLastName = "DOE",
                        PrimaryDOB = "06/19/2010",
                        Address1 = "1234 FAKE CT",
                        Address2 = null,
                        City = "MYCITY",
                        State = "NC",
                        Zip = "28451",
                        County = string.Empty,
                        DriversLicenseNumber = "123456789"
                    }
                },
                new object[]
                {
                    "OHMYCITY%5EDOE%24JOHN%24M%24%5E1234%20FAKE%20BLVD%5E6360231820123456789%3D18032010030810442242452%20%20D%20A",
                    new CustomerShell
                    {
                        PrimaryFirstName = "JOHN",
                        PrimaryMiddleName = "M",
                        PrimaryLastName = "DOE",
                        PrimaryDOB = "03/08/2010",
                        Address1 = "1234 FAKE BLVD",
                        Address2 = null,
                        City = "MYCITY",
                        State = "OH",
                        Zip = "44224-2452",
                        County = string.Empty,
                        DriversLicenseNumber = "123456789"
                    }
                },
                new object[]
                {
                    "OHMYCITY%5EDOE%24JOHN%24M%24%5E1234%20FAKE%20BLVD%5E6360231820123456789%3D18032010030810442242452%20%20D%20A%20%20%20%20%20%20%20%20%20%20%20%20%201601205BROHAZ&",
                    new CustomerShell
                    {
                        PrimaryFirstName = "JOHN",
                        PrimaryMiddleName = "M",
                        PrimaryLastName = "DOE",
                        PrimaryDOB = "03/08/2010",
                        Address1 = "1234 FAKE BLVD",
                        Address2 = null,
                        City = "MYCITY",
                        State = "OH",
                        Zip = "44224-2452",
                        County = string.Empty,
                        DriversLicenseNumber = "123456789"
                    }
                },
                new object[]
                {
                    "%40%0A%0DANSI%20636060040002DL00410263ZW03040037DCAC%0ADCBNONE%0ADCDNONE%0ADBA20201215%0ADCSDOE%0ADACJOHN%20CHESTER%0ADAD%0ADBD20160929%0ADBB20100428%0ADBC1%0ADAYBLU%0ADAU073%20IN%0ADAG1234%20FAKE%20BLVD%0ADAIMYCITY%0ADAJWY%0ADAK44224-2452%20%20%20%20%20%20%0ADAQ123456789%0ADCF54576301%0ADCGUSA%0ADDEU%0ADDFU%0ADDGU%0ADAHLARAMIE,%20WY%20%2082072%0ADAZBRO%0ADCJ20161010_003008_4_471%0AZWZWA%0AZWBY%0AZWC%0AZWD%0AZWE%0AZWF0060-57020%0A",
                    new CustomerShell
                    {
                        PrimaryFirstName = "JOHN",
                        PrimaryMiddleName = "CHESTER",
                        PrimaryLastName = "DOE",
                        PrimaryDOB = "04/28/2010",
                        Address1 = "1234 FAKE BLVD",
                        Address2 = null,
                        City = "MYCITY",
                        State = "WY",
                        Zip = "44224",
                        County = string.Empty,
                        DriversLicenseNumber = "123456789"
                    }
                },
                new object[]
                {
                    "%40%0A%1E%0DANSI+636060040002DL00410263ZW03040037DCAC%0ADCBNONE%0ADCDNONE%0ADBA20201215%0ADCSDOE%0ADACJOHN+CHESTER%0ADAD%0ADBD20160929%0ADBB20100428%0ADBC1%0ADAYBLU%0ADAU073+IN%0ADAG1234 FAKE BLVD%0ADAIMYCITY%0ADAJWY%0ADAK44224++++++%0ADAQ123456789%0ADCF54576301%0ADCGUSA%0ADDEU%0ADDFU%0ADDGU%0ADAHLARAMIE%2C+WY++82072%0ADAZBRO%0ADCJ20161010_003008_4_471%0AZWZWA%0AZWBY%0AZWC%0AZWD%0AZWE%0AZWF0060-57020%0A",
                    new CustomerShell
                    {
                        PrimaryFirstName = "JOHN",
                        PrimaryMiddleName = "CHESTER",
                        PrimaryLastName = "DOE",
                        PrimaryDOB = "04/28/2010",
                        Address1 = "1234 FAKE BLVD",
                        Address2 = null,
                        City = "MYCITY",
                        State = "WY",
                        Zip = "44224",
                        County = string.Empty,
                        DriversLicenseNumber = "123456789"
                    }
                },
                new object[]
                {
                    "%40%0A%0DANSI%206360250101DL00290191DLDAQ123456789%0ADAAJOHN%20CHESTER%20DOE%0ADAG1234 FAKE BLVD%0ADAIMYCITY%0ADAJPA%0ADAK44224%20%20%20%20%20%20%0ADARC%20%20%20%0ADAS*%2F*%20%20%20%20%20%20%20%20%20%20%20%20%20%0ADAT----%20%0ADAU600%0ADAYBRO%0ADBA20210305%0ADBB20100428%0ADBCM%0ADBD20170304%0ADBF00%0ADBHN%0D",
                    new CustomerShell
                    {
                        PrimaryFirstName = "JOHN",
                        PrimaryMiddleName = "CHESTER",
                        PrimaryLastName = "DOE",
                        PrimaryDOB = "04/28/2010",
                        Address1 = "1234 FAKE BLVD",
                        Address2 = null,
                        City = "MYCITY",
                        State = "PA",
                        Zip = "44224",
                        County = string.Empty,
                        DriversLicenseNumber = "123456789"
                    }
                },
                new object[]
                {
                    "%40%0A%1E%0DANSI+6360250101DL00290197DLDAQ123456789%0ADAAJOHN+CHESTER+DOE%0ADAG1234 FAKE BLVD%0ADAIMYCITY%0ADAJPA%0ADAK44224+++++%0ADARC+%0ADAS*%2F*+++++++++++%0ADAT----%0ADAU508%0ADAYBRO%0ADBA20200626%0ADBB20100428%0ADBCM%0ADBD20170328%0ADBF00%0ADBHN%0D",
                    new CustomerShell
                    {
                        PrimaryFirstName = "JOHN",
                        PrimaryMiddleName = "CHESTER",
                        PrimaryLastName = "DOE",
                        PrimaryDOB = "04/28/2010",
                        Address1 = "1234 FAKE BLVD",
                        Address2 = null,
                        City = "MYCITY",
                        State = "PA",
                        Zip = "44224",
                        County = string.Empty,
                        DriversLicenseNumber = "123456789"
                    }
                },
                new object[]
                {
                    "%40%0A%1E%0DANSI+6360250101DL00290191DLDAQ123456789%0ADAAJOHN+DOE%0ADAG1234 FAKE BLVD%0ADAIMYCITY%0ADAJPA%0ADAK44224+++++%0ADARC+%0ADAS*%2F1+++++++++++%0ADAT----%0ADAU509%0ADAYBLU%0ADBA20210612%0ADBB20100428%0ADBCF%0ADBD20170607%0ADBF00%0ADBHY%0D",
                    new CustomerShell
                    {
                        PrimaryFirstName = "JOHN",
                        PrimaryMiddleName = null,
                        PrimaryLastName = "DOE",
                        PrimaryDOB = "04/28/2010",
                        Address1 = "1234 FAKE BLVD",
                        Address2 = null,
                        City = "MYCITY",
                        State = "PA",
                        Zip = "44224",
                        County = string.Empty,
                        DriversLicenseNumber = "123456789"
                    }
                },
                new object[]
                {
                    "%40%0A%0DANSI%206360250101DL00290191DLDAQ123456789%0ADAAJOHN%20DOE%0ADAG1234 FAKE BLVD%0ADAIMYCITY%0ADAJPA%0ADAK44224%20%20%20%20%20%20%0ADARC%20%20%20%0ADAS*%2F1%20%20%20%20%20%20%20%20%20%20%20%20%20%0ADAT----%20%0ADAU509%0ADAYBLU%0ADBA20210612%0ADBB20100428%0ADBCF%0ADBD20170607%0ADBF00%0ADBHY%0D",
                    new CustomerShell
                    {
                        PrimaryFirstName = "JOHN",
                        PrimaryMiddleName = null,
                        PrimaryLastName = "DOE",
                        PrimaryDOB = "04/28/2010",
                        Address1 = "1234 FAKE BLVD",
                        Address2 = null,
                        City = "MYCITY",
                        State = "PA",
                        Zip = "44224",
                        County = string.Empty,
                        DriversLicenseNumber = "123456789"
                    }
                },
                new object[]
                {
                    "%40%0A%0DAAMVA6360250101DL00290181DAQ123456789%0ADAAJOHN%20CHESTER%20DOE%0ADAG1234 FAKE BLVD%0ADAIMYCITY%0ADAJPA%0ADAK44224%20%20%20%20%20%20%0ADARC%20%20%20%0ADAS*%2F1%20%20%20%20%20%20%20%20%20%20%20%20%20%0ADAT----%20%0ADAU603%0ADAYBRO%0ADBA20171022%0ADBB20100428%0ADBCM%0ADBD20131030%0ADBF00%0ADBHN%0D",
                    new CustomerShell
                    {
                        PrimaryFirstName = "JOHN",
                        PrimaryMiddleName = "CHESTER",
                        PrimaryLastName = "DOE",
                        PrimaryDOB = "04/28/2010",
                        Address1 = "1234 FAKE BLVD",
                        Address2 = null,
                        City = "MYCITY",
                        State = "PA",
                        Zip = "44224",
                        County = string.Empty,
                        DriversLicenseNumber = "123456789"
                    }
                },
                new object[]
                {
                    "%40%0A%1C%0DAAMVA6360250101DL00290181DAQ123456789%0ADAAJOHN+CHESTER+DOE%0ADAG1234 FAKE BLVD%0ADAIMYCITY%0ADAJPA%0ADAK44224++++++%0ADARC+++%0ADAS*%2F1+++++++++++++%0ADAT----+%0ADAU603%0ADAYBRO%0ADBA20171022%0ADBB20100428%0ADBCM%0ADBD20131030%0ADBF00%0ADBHN%0D",
                    new CustomerShell
                    {
                        PrimaryFirstName = "JOHN",
                        PrimaryMiddleName = "CHESTER",
                        PrimaryLastName = "DOE",
                        PrimaryDOB = "04/28/2010",
                        Address1 = "1234 FAKE BLVD",
                        Address2 = null,
                        City = "MYCITY",
                        State = "PA",
                        Zip = "44224",
                        County = string.Empty,
                        DriversLicenseNumber = "123456789"
                    }
                },
                new object[]
                {
                    "%40%0A%0DAAMVA6360250101DL00290184DAQ123456789%0ADAAJOHN%20DOE%0ADAG1234 FAKE BLVD%0ADAIMYCITY%0ADAJPA%0ADAK44224%20%20%20%20%20%20%0ADARC%20%20%20%0ADAS*%2F1%20%20%20%20%20%20%20%20%20%20%20%20%20%0ADAT----%20%0ADAU508%0ADAYBLK%0ADBA20181009%0ADBB20100428%0ADBCM%0ADBD20141028%0ADBF00%0ADBHN%0D",
                    new CustomerShell
                    {
                        PrimaryFirstName = "JOHN",
                        PrimaryMiddleName = null,
                        PrimaryLastName = "DOE",
                        PrimaryDOB = "04/28/2010",
                        Address1 = "1234 FAKE BLVD",
                        Address2 = null,
                        City = "MYCITY",
                        State = "PA",
                        Zip = "44224",
                        County = string.Empty,
                        DriversLicenseNumber = "123456789"
                    }
                },
                new object[]
                {
                    "%40%0A%1C%0DAAMVA6360250101DL00290184DAQ123456789%0ADAAJOHN+DOE%0ADAG1234 FAKE BLVD%0ADAIMYCITY%0ADAJPA%0ADAK44224++++++%0ADARC+++%0ADAS*%2F1+++++++++++++%0ADAT----+%0ADAU508%0ADAYBLK%0ADBA20181009%0ADBB20100428%0ADBCM%0ADBD20141028%0ADBF00%0ADBHN%0D",
                    new CustomerShell
                    {
                        PrimaryFirstName = "JOHN",
                        PrimaryMiddleName = null,
                        PrimaryLastName = "DOE",
                        PrimaryDOB = "04/28/2010",
                        Address1 = "1234 FAKE BLVD",
                        Address2 = null,
                        City = "MYCITY",
                        State = "PA",
                        Zip = "44224",
                        County = string.Empty,
                        DriversLicenseNumber = "123456789"
                    }
                },
                new object[]
                {
                    "%40%0A%0DAAMVA6360250101DL00290219DAQ123456789%0ADAAJOHN%20CHESTER%20DOE%20JR%20%20%20%20%20%20%20%20%20%20%20%0ADAG1234 FAKE BLVD%20%20%20%20%20%20%20%20%0ADAIMYCITY%0ADAJPA%0ADAK44224%20%20%20%20%20%20%0ADARC%20%20%20%0ADAS*%2F1%20%20%20%20%20%20%20%20%20%20%20%20%20%0ADAT----%20%0ADAU507%0ADAYHZ%0ADBA20180529%0ADBB20100428%0ADBCM%0ADBD20150408%0ADBF01%0ADBHN%0D",
                    new CustomerShell
                    {
                        PrimaryFirstName = "JOHN",
                        PrimaryMiddleName = "CHESTER",
                        PrimaryLastName = "DOE JR",
                        PrimaryDOB = "04/28/2010",
                        Address1 = "1234 FAKE BLVD",
                        Address2 = null,
                        City = "MYCITY",
                        State = "PA",
                        Zip = "44224",
                        County = string.Empty,
                        DriversLicenseNumber = "123456789"
                    }
                },
                new object[]
                {
                    "%40%0A%1C%0DAAMVA6360250101DL00290219DAQ123456789%0ADAAJOHN+CHESTER+DOE+JR+++++++++++%0ADAG1234 FAKE BLVD++++++++%0ADAIMYCITY%0ADAJPA%0ADAK44224++++++%0ADARC+++%0ADAS*%2F1+++++++++++++%0ADAT----+%0ADAU507%0ADAYHZ%0ADBA20180529%0ADBB20100428%0ADBCM%0ADBD20150408%0ADBF01%0ADBHN%0D",
                    new CustomerShell
                    {
                        PrimaryFirstName = "JOHN",
                        PrimaryMiddleName = "CHESTER",
                        PrimaryLastName = "DOE JR",
                        PrimaryDOB = "04/28/2010",
                        Address1 = "1234 FAKE BLVD",
                        Address2 = null,
                        City = "MYCITY",
                        State = "PA",
                        Zip = "44224",
                        County = string.Empty,
                        DriversLicenseNumber = "123456789"
                    }
                },
                new object[]
                {
                    "%40%0A%1C%0DAAMVA6360250101DL00290219DAQ123456789%0ADAAJOHN+CHESTER+LAUD+DOE+++++++++++%0ADAG1234 FAKE BLVD++++++++%0ADAIMYCITY%0ADAJPA%0ADAK44224++++++%0ADARC+++%0ADAS*%2F1+++++++++++++%0ADAT----+%0ADAU507%0ADAYHZ%0ADBA20180529%0ADBB20100428%0ADBCM%0ADBD20150408%0ADBF01%0ADBHN%0D",
                    new CustomerShell
                    {
                        PrimaryFirstName = "JOHN",
                        PrimaryMiddleName = "CHESTER LAUD",
                        PrimaryLastName = "DOE",
                        PrimaryDOB = "04/28/2010",
                        Address1 = "1234 FAKE BLVD",
                        Address2 = null,
                        City = "MYCITY",
                        State = "PA",
                        Zip = "44224",
                        County = string.Empty,
                        DriversLicenseNumber = "123456789"
                    }
                },
                new object[]
                {
                    "%40%0A%1C%0DAAMVA6360250101DL00290219DAQ123456789%0ADAAJOHN+CHESTER+LAUD+DOE+JR+++++++++++%0ADAG1234 FAKE BLVD++++++++%0ADAIMYCITY%0ADAJPA%0ADAK44224++++++%0ADARC+++%0ADAS*%2F1+++++++++++++%0ADAT----+%0ADAU507%0ADAYHZ%0ADBA20180529%0ADBB20100428%0ADBCM%0ADBD20150408%0ADBF01%0ADBHN%0D",
                    new CustomerShell
                    {
                        PrimaryFirstName = "JOHN",
                        PrimaryMiddleName = "CHESTER LAUD",
                        PrimaryLastName = "DOE JR",
                        PrimaryDOB = "04/28/2010",
                        Address1 = "1234 FAKE BLVD",
                        Address2 = null,
                        City = "MYCITY",
                        State = "PA",
                        Zip = "44224",
                        County = string.Empty,
                        DriversLicenseNumber = "123456789"
                    }
                },
                new object[]
                {
                    "%40%0A%1C%0DAAMVA6360250101DL00290219DAQ123456789%0ADAAJOHN+CHESTER+LAUD+PHILLIP+DOE+++++++++++%0ADAG1234 FAKE BLVD++++++++%0ADAIMYCITY%0ADAJPA%0ADAK44224++++++%0ADARC+++%0ADAS*%2F1+++++++++++++%0ADAT----+%0ADAU507%0ADAYHZ%0ADBA20180529%0ADBB20100428%0ADBCM%0ADBD20150408%0ADBF01%0ADBHN%0D",
                    new CustomerShell
                    {
                        PrimaryFirstName = "JOHN",
                        PrimaryMiddleName = "CHESTER LAUD PHILLIP",
                        PrimaryLastName = "DOE",
                        PrimaryDOB = "04/28/2010",
                        Address1 = "1234 FAKE BLVD",
                        Address2 = null,
                        City = "MYCITY",
                        State = "PA",
                        Zip = "44224",
                        County = string.Empty,
                        DriversLicenseNumber = "123456789"
                    }
                },
                new object[]
                {
                    "%40%0A%1C%0DAAMVA6360250101DL00290219DAQ123456789%0ADAAJOHN+CHESTER+LAUD+PHILLIP+DOE+JR+++++++++++%0ADAG1234 FAKE BLVD++++++++%0ADAIMYCITY%0ADAJPA%0ADAK44224++++++%0ADARC+++%0ADAS*%2F1+++++++++++++%0ADAT----+%0ADAU507%0ADAYHZ%0ADBA20180529%0ADBB20100428%0ADBCM%0ADBD20150408%0ADBF01%0ADBHN%0D",
                    new CustomerShell
                    {
                        PrimaryFirstName = "JOHN",
                        PrimaryMiddleName = "CHESTER LAUD PHILLIP",
                        PrimaryLastName = "DOE JR",
                        PrimaryDOB = "04/28/2010",
                        Address1 = "1234 FAKE BLVD",
                        Address2 = null,
                        City = "MYCITY",
                        State = "PA",
                        Zip = "44224",
                        County = string.Empty,
                        DriversLicenseNumber = "123456789"
                    }
                },
                new object[]
                {
                    "%40%0A%0DANSI%20636025090002DL00410259ZP03000027DLDAQ123456789%0ADCSDOE%0ADDEN%0ADACJOHN%0ADDFN%0ADADCHESTER%0ADDGN%0ADCACM%0ADCBNONE%0ADCDNONE%0ADBD10052017%0ADBB04282010%0ADBA10022021%0ADBC1%0ADAU072%20IN%0ADAYBRO%0ADAG1234%20FAKE%20BLVD%0ADAIMYCITY%0ADAJPA%0ADAK442240000%20%20%0ADCF1727801202705000000006734%0ADCGUSA%0ADCK0250094436817163%0ADDB06072016%0DZPZPA%0AZPB00%0AZPC019%0AZPDNONE%0D",
                    new CustomerShell
                    {
                        PrimaryFirstName = "JOHN",
                        PrimaryMiddleName = "CHESTER",
                        PrimaryLastName = "DOE",
                        PrimaryDOB = "04/28/2010",
                        Address1 = "1234 FAKE BLVD",
                        Address2 = null,
                        City = "MYCITY",
                        State = "PA",
                        Zip = "44224",
                        County = string.Empty,
                        DriversLicenseNumber = "123456789"
                    }
                },
                new object[]
                {
                    "%40%0A%0DANSI%20636025090002DL00410259ZP03000027DLDAQ123456789%0ADCSDOE%0ADDEN%0ADACJOHN%0ADDFN%0ADADCHESTER%20LAUD%0ADDGN%0ADCACM%0ADCBNONE%0ADCDNONE%0ADBD10052017%0ADBB04282010%0ADBA10022021%0ADBC1%0ADAU072%20IN%0ADAYBRO%0ADAG1234%20FAKE%20BLVD%0ADAIMYCITY%0ADAJPA%0ADAK442240000%20%20%0ADCF1727801202705000000006734%0ADCGUSA%0ADCK0250094436817163%0ADDB06072016%0DZPZPA%0AZPB00%0AZPC019%0AZPDNONE%0D",
                    new CustomerShell
                    {
                        PrimaryFirstName = "JOHN",
                        PrimaryMiddleName = "CHESTER LAUD",
                        PrimaryLastName = "DOE",
                        PrimaryDOB = "04/28/2010",
                        Address1 = "1234 FAKE BLVD",
                        Address2 = null,
                        City = "MYCITY",
                        State = "PA",
                        Zip = "44224",
                        County = string.Empty,
                        DriversLicenseNumber = "123456789"
                    }
                },
                new object[]
                {
                    "%40%0A%0DANSI%206360350201DL00290190DLDAADOE,JOHN,CHESTER%0ADAQ123456789%0ADBA20181224%0ADBB20100428%0ADAG1234 FAKE BLVD%0ADAIMYCITY%0ADAJIL%0ADAK442240000%20%20%0ADARD%0ADAS********%20%20%0ADAT*****%0ADBD20140529%0ADBCF%0ADAU503%0ADAW125%0ADAYBLU%0A%0D",
                    new CustomerShell
                    {
                        PrimaryFirstName = "JOHN",
                        PrimaryMiddleName = "CHESTER",
                        PrimaryLastName = "DOE",
                        PrimaryDOB = "04/28/2010",
                        Address1 = "1234 FAKE BLVD",
                        Address2 = null,
                        City = "MYCITY",
                        State = "IL",
                        Zip = "44224",
                        County = string.Empty,
                        DriversLicenseNumber = "123456789"
                    }
                },
                new object[]
                {
                    "%40%0A%1C%0DANSI+6360350201DL00290190DLDAADOE%2CJOHN%2CCHESTER%0ADAQ123456789%0ADBA20181224%0ADBB20100428%0ADAG1234 FAKE BLVD%0ADAIMYCITY%0ADAJIL%0ADAK442240000++%0ADARD%0ADAS********++%0ADAT*****%0ADBD20140529%0ADBCF%0ADAU503%0ADAW125%0ADAYBLU%0A%0D",
                    new CustomerShell
                    {
                        PrimaryFirstName = "JOHN",
                        PrimaryMiddleName = "CHESTER",
                        PrimaryLastName = "DOE",
                        PrimaryDOB = "04/28/2010",
                        Address1 = "1234 FAKE BLVD",
                        Address2 = null,
                        City = "MYCITY",
                        State = "IL",
                        Zip = "44224",
                        County = string.Empty,
                        DriversLicenseNumber = "123456789"
                    }
                },
                new object[]
                {
                    "%40%0A%0DANSI%20636045030002DL00410241ZW02820051DLDCSDOE%0ADCTJOHN%20CHESTER%0ADCU%0ADAG1234 FAKE BLVD%0ADAIMYCITY%0ADAJWA%0ADAK442249142%20%20%0ADCGUSA%0ADAQ123456789%0ADCANONE%0ADCBNONE%0ADCDNONE%0ADCF12345678932152304B1136%0ADCHNONE%0ADBA08172021%0ADBB04282010%0ADBC1%0ADBD08182015%0ADAU071%20in%0ADCE4%0ADAYHAZ%0DZWZWA152304B1136%0AZWB%0AZWC32%0AZWD%0AZWE%0AZWFRev03122007%0A%0D",
                    new CustomerShell
                    {
                        PrimaryFirstName = "JOHN",
                        PrimaryMiddleName = "CHESTER",
                        PrimaryLastName = "DOE",
                        PrimaryDOB = "04/28/2010",
                        Address1 = "1234 FAKE BLVD",
                        Address2 = null,
                        City = "MYCITY",
                        State = "WA",
                        Zip = "44224",
                        County = string.Empty,
                        DriversLicenseNumber = "123456789"
                    }
                },
                new object[]
                {
                    "%40%0A%1E%0DANSI+636045030002DL00410241ZW02820051DLDCSDOE%0ADCTJOHN+CHESTER%0ADCU%0ADAG1234 FAKE BLVD%0ADAIMYCITY%0ADAJWA%0ADAK442249142++%0ADCGUSA%0ADAQ123456789%0ADCANONE%0ADCBNONE%0ADCDNONE%0ADCF12345678932152304B1136%0ADCHNONE%0ADBA08172021%0ADBB04282010%0ADBC1%0ADBD08182015%0ADAU071+in%0ADCE4%0ADAYHAZ%0DZWZWA152304B1136%0AZWB%0AZWC32%0AZWD%0AZWE%0AZWFRev03122007%0A%0D",
                    new CustomerShell
                    {
                        PrimaryFirstName = "JOHN",
                        PrimaryMiddleName = "CHESTER",
                        PrimaryLastName = "DOE",
                        PrimaryDOB = "04/28/2010",
                        Address1 = "1234 FAKE BLVD",
                        Address2 = null,
                        City = "MYCITY",
                        State = "WA",
                        Zip = "44224",
                        County = string.Empty,
                        DriversLicenseNumber = "123456789"
                    }
                },
                new object[]
                {
                    "%40%0A%0DANSI%20636045030002DL00410241ZW02820051DLDCANONE%0ADCBNONE%0ADCDNONE%0ADBA05052023%0ADCSDOE%0ADCTJOHN%0ADCU%0ADBD05022017%0ADBB04282010%0ADBC1%0ADAYBLK%0ADAU066%20in%0ADCE3%0ADAG1234 FAKE BLVD%0ADAIMYCITY%0ADAJWA%0ADAK442244027%20%20%0ADAQ123456789%0ADCF12345678932171223A1326%0ADCGUSA%0ADCHNONE%0A%0DZWZWA171223A1326%0AZWB%0AZWC32%0AZWD%0AZWE%0AZWFRev09162009%0A%0D",
                    new CustomerShell
                    {
                        PrimaryFirstName = "JOHN",
                        PrimaryMiddleName = null,
                        PrimaryLastName = "DOE",
                        PrimaryDOB = "04/28/2010",
                        Address1 = "1234 FAKE BLVD",
                        Address2 = null,
                        City = "MYCITY",
                        State = "WA",
                        Zip = "44224",
                        County = string.Empty,
                        DriversLicenseNumber = "123456789"
                    }
                },
                new object[]
                {
                    "%40%0A%1E%0DANSI+636045030002DL00410241ZW02820051DLDCANONE%0ADCBNONE%0ADCDNONE%0ADBA05052023%0ADCSDOE%0ADCTJOHN%0ADCU%0ADBD05022017%0ADBB04282010%0ADBC1%0ADAYBLK%0ADAU066+in%0ADCE3%0ADAG1234 FAKE BLVD%0ADAIMYCITY%0ADAJWA%0ADAK442244027++%0ADAQ123456789%0ADCF12345678932171223A1326%0ADCGUSA%0ADCHNONE%0A%0DZWZWA171223A1326%0AZWB%0AZWC32%0AZWD%0AZWE%0AZWFRev09162009%0A%0D",
                    new CustomerShell
                    {
                        PrimaryFirstName = "JOHN",
                        PrimaryMiddleName = null,
                        PrimaryLastName = "DOE",
                        PrimaryDOB = "04/28/2010",
                        Address1 = "1234 FAKE BLVD",
                        Address2 = null,
                        City = "MYCITY",
                        State = "WA",
                        Zip = "44224",
                        County = string.Empty,
                        DriversLicenseNumber = "123456789"
                    }
                },
                new object[]
                {
                    "%40%0A%1E%0DAAMVA6360060101DL00290175DAADOE%2CJOHN%2CCHESTER%0ADAG1234 FAKE BLVD%0ADAIMYCITY%0ADAJCT%0ADAK44224+++++%0ADAQ123456789%0ADARD+%0ADAS++++++++%0ADAT++++%0ADBA20210701%0ADBB20100428%0ADBC2%0ADBD20150618%0ADAU507%0ADAYHAZ%0ADBF00%0ADBHN%0D",
                    new CustomerShell
                    {
                        PrimaryFirstName = "JOHN",
                        PrimaryMiddleName = "CHESTER",
                        PrimaryLastName = "DOE",
                        PrimaryDOB = "04/28/2010",
                        Address1 = "1234 FAKE BLVD",
                        Address2 = null,
                        City = "MYCITY",
                        State = "CT",
                        Zip = "44224",
                        County = string.Empty,
                        DriversLicenseNumber = "123456789"
                    }
                },
                new object[]
                {
                    "%40%0A%0DAAMVA6360060101DL00290175DAADOE,JOHN,CHESTER%0ADAG1234 FAKE BLVD%0ADAIMYCITY%0ADAJCT%0ADAK44224%20%20%20%20%20%20%0ADAQ123456789%0ADARD%20%20%20%0ADAS%20%20%20%20%20%20%20%20%20%20%0ADAT%20%20%20%20%20%0ADBA20210701%0ADBB20100428%0ADBC2%0ADBD20150618%0ADAU507%0ADAYHAZ%0ADBF00%0ADBHN%0D",
                    new CustomerShell
                    {
                        PrimaryFirstName = "JOHN",
                        PrimaryMiddleName = "CHESTER",
                        PrimaryLastName = "DOE",
                        PrimaryDOB = "04/28/2010",
                        Address1 = "1234 FAKE BLVD",
                        Address2 = null,
                        City = "MYCITY",
                        State = "CT",
                        Zip = "44224",
                        County = string.Empty,
                        DriversLicenseNumber = "123456789"
                    }
                },
                new object[]
                {
                    "%40%0A%1E%0DANSI+6360290102DL00390183ZO02220025DLDAQW+123+456+789+012%0ADAADOE%2C+JOHN%0ADAG%0ADAL1234+FAKE+BLVD%0ADAIMYCITY%0ADAJOR%0ADAK44224++++++%0ADARC+++%0ADASD+++++++++%0ADAT++++++%0ADAU508%0ADAW160%0ADBA20251227%0ADBB20100428%0ADBC1%0ADBD20171214%0AZOZOARECORD+CREATED+1995%0A",
                    new CustomerShell
                    {
                        PrimaryFirstName = "JOHN",
                        PrimaryMiddleName = null,
                        PrimaryLastName = "DOE",
                        PrimaryDOB = "04/28/2010",
                        Address1 = "1234 FAKE BLVD",
                        Address2 = null,
                        City = "MYCITY",
                        State = "OR",
                        Zip = "44224",
                        County = string.Empty,
                        DriversLicenseNumber = "W 123 456 789 012"
                    }
                },
                new object[]
                {
                    "%40%0A%1E%0DANSI+6360290102DL00390183ZO02220025DLDAQW+123+456+789+012%0ADAADOE%2C+JOHN+CHESTER%0ADAG%0ADAL1234+FAKE+BLVD%0ADAIMYCITY%0ADAJOR%0ADAK44224++++++%0ADARC+++%0ADASD+++++++++%0ADAT++++++%0ADAU508%0ADAW160%0ADBA20251227%0ADBB20100428%0ADBC1%0ADBD20171214%0AZOZOARECORD+CREATED+1995%0A",
                    new CustomerShell
                    {
                        PrimaryFirstName = "JOHN",
                        PrimaryMiddleName = "CHESTER",
                        PrimaryLastName = "DOE",
                        PrimaryDOB = "04/28/2010",
                        Address1 = "1234 FAKE BLVD",
                        Address2 = null,
                        City = "MYCITY",
                        State = "OR",
                        Zip = "44224",
                        County = string.Empty,
                        DriversLicenseNumber = "W 123 456 789 012"
                    }
                },
                new object[]
                {
                    "%40%0A%1E%0DANSI+6360290102DL00390188ZO02270031DLDAQW+123+456+789+012%0ADAALAUD+DOE%2C+JOHN+CHESTER%0ADAG%0ADAL1234+FAKE+BLVD%0ADAIMYCITY%0ADAJOR%0ADAK44224++++++%0ADARC+++%0ADASD+++++++++%0ADATM+++++%0ADAU510%0ADAW270%0ADBA20201028%0ADBB20100428%0ADBC1%0ADBD20190305%0AZOZOAFIRST+LICENSED+10-20-2004%0A",
                    new CustomerShell
                    {
                        PrimaryFirstName = "JOHN",
                        PrimaryMiddleName = "CHESTER LAUD",
                        PrimaryLastName = "DOE",
                        PrimaryDOB = "04/28/2010",
                        Address1 = "1234 FAKE BLVD",
                        Address2 = null,
                        City = "MYCITY",
                        State = "OR",
                        Zip = "44224",
                        County = string.Empty,
                        DriversLicenseNumber = "W 123 456 789 012"
                    }
                },
                new object[]
                {
                    "%40%0A%0DANSI%206360380101DL00290055DLDAQ123456789%0ADAADOE%20CHESTER%20JOHN%0ADBB20100428%0D",
                    new CustomerShell
                    {
                        PrimaryFirstName = "JOHN",
                        PrimaryMiddleName = "CHESTER",
                        PrimaryLastName = "DOE",
                        PrimaryDOB = "04/28/2010",
                        Address1 = null,
                        Address2 = null,
                        City = null,
                        State = null,
                        Zip = null,
                        County = string.Empty,
                        DriversLicenseNumber = "123456789"
                    }
                },
                new object[]
                {
                    "%40%0A%0DANSI%206360380101DL00290055DLDAQ123456789%0ADAADOE%20JOHN%0ADBB20100428%0D",
                    new CustomerShell
                    {
                        PrimaryFirstName = "JOHN",
                        PrimaryMiddleName = null,
                        PrimaryLastName = "DOE",
                        PrimaryDOB = "04/28/2010",
                        Address1 = null,
                        Address2 = null,
                        City = null,
                        State = null,
                        Zip = null,
                        County = string.Empty,
                        DriversLicenseNumber = "123456789"
                    }
                },
                new object[]
                {
                    "%40%0A%0DANSI%20636038090002DL00410295ZM03360012DLDAQ123456789%0ADCSDOE%0ADDEN%0ADACJOHN%0ADDFN%0ADADCHESTER%0ADDGN%0ADCAD%0ADCB2%0ADCDNONE%0ADBD04032019%0ADBB04282010%0ADBA04082023%0ADBC1%0ADAU071%20in%0ADAYBRO%0ADAG1234%20FAKE%20BLVD%0ADAIMYCITY%0ADAJMN%0ADAK442241234%20%20%0ADCF00000000975498%0ADCGUSA%0ADAW160%0ADCKH3080943473110119001%0ADDAN%0ADDB10232017%0ADDJ04082019%0ADDK1%0DZMZMAN%0AZMBN%0D",
                    new CustomerShell
                    {
                        PrimaryFirstName = "JOHN",
                        PrimaryMiddleName = "CHESTER",
                        PrimaryLastName = "DOE",
                        PrimaryDOB = "04/28/2010",
                        Address1 = "1234 FAKE BLVD",
                        Address2 = null,
                        City = "MYCITY",
                        State = "MN",
                        Zip = "44224",
                        County = string.Empty,
                        DriversLicenseNumber = "123456789"
                    }
                },
                new object[]
                {
                    "%40%0A%0DANSI%20636038090002DL00410295ZM03360012DLDAQ123456789%0ADCSDOE%0ADDEN%0ADACJOHN%0ADDFN%0ADADCHESTER%20LAUD%0ADDGN%0ADCAD%0ADCB2%0ADCDNONE%0ADBD04032019%0ADBB04282010%0ADBA04082023%0ADBC1%0ADAU071%20in%0ADAYBRO%0ADAG1234%20FAKE%20BLVD%0ADAIMYCITY%0ADAJMN%0ADAK442241234%20%20%0ADCF00000000975498%0ADCGUSA%0ADAW160%0ADCKH3080943473110119001%0ADDAN%0ADDB10232017%0ADDJ04082019%0ADDK1%0DZMZMAN%0AZMBN%0D",
                    new CustomerShell
                    {
                        PrimaryFirstName = "JOHN",
                        PrimaryMiddleName = "CHESTER LAUD",
                        PrimaryLastName = "DOE",
                        PrimaryDOB = "04/28/2010",
                        Address1 = "1234 FAKE BLVD",
                        Address2 = null,
                        City = "MYCITY",
                        State = "MN",
                        Zip = "44224",
                        County = string.Empty,
                        DriversLicenseNumber = "123456789"
                    }
                }
            };

        [Theory, MemberData(nameof(GetDataSets)), Trait("Category", "Unit")]
        public void Test_DriverLicenseParser(string data, CustomerShell result)
        {
            var license = DriverLicenseParser.TestParseData(HttpUtility.UrlDecode(data));
            Assert.AreEqual(result.PrimaryFirstName, license.PrimaryFirstName);
            Assert.AreEqual(result.PrimaryMiddleName, license.PrimaryMiddleName);
            Assert.AreEqual(result.PrimaryLastName, license.PrimaryLastName);
            Assert.AreEqual(result.PrimaryDOB, license.PrimaryDOB);
            Assert.AreEqual(result.Address1, license.Address1);
            Assert.AreEqual(result.Address2, license.Address2);
            Assert.AreEqual(result.City, license.City);
            Assert.AreEqual(result.State, license.State);
            Assert.AreEqual(result.Zip, license.Zip);
            Assert.AreEqual(result.County, license.County);
            Assert.AreEqual(result.DriversLicenseNumber, license.DriversLicenseNumber);
        }
    }
}*/