/*
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
*/