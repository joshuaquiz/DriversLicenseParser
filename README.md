[![.NET](https://github.com/joshuaquiz/DriversLicenseParser/actions/workflows/dotnet.yml/badge.svg?branch=main)](https://github.com/joshuaquiz/DriversLicenseParser/actions/workflows/dotnet.yml)

# Drivers License Parser
Drivers licenses in the USA are all over the map and there are some sugestions that states follow but not all of them. How do you handle these differences? You could write and maintain this on your own or use an API that can parse the data from the bar code. If you want to do the former then feel free to copy this code, it is offered as is. If you want to use an API you can see the blow documentation on how to do that.

### AAMVA Element IDs

Below is a table of AAMVA Element Ids and the fields to which they map by AAMVA Version. Not all license match exactly to one of these standards and those differences are documented below as well.

**bold** = Mandatory Field

`--` = not included in this version of the standard

| Field                  | Version 1 | Version 2 | Version 3 | Version 4 | Version 5 | Version 6 | Version 7 | Version 8 | Supported |
|:-----------------------|:---------:|:---------:|:---------:|:---------:|:---------:|:---------:|:---------:|:---------:|:---------:|
| First Name             |    DAC    |  **DCT**  |  **DCT**  |  **DAC**  |  **DAC**  |  **DAC**  |  **DAC**  |  **DAC**  |     Y     |
| Last Name              |    DAB    |  **DCS**  |  **DCS**  |  **DCS**  |  **DCS**  |  **DCS**  |  **DCS**  |  **DCS**  |     Y     |
| Middle Name            |    DAD    |  **DAD**  |  **DAD**  |  **DAD**  |  **DAD**  |  **DAD**  |  **DAD**  |  **DAD**  |     Y     |
| Expiration Date        |  **DBA**  |  **DBA**  |  **DBA**  |  **DBA**  |  **DBA**  |  **DBA**  |  **DBA**  |  **DBA**  |     Y     |
| Issue Date             |  **DBD**  |  **DBD**  |  **DBD**  |  **DBD**  |  **DBD**  |  **DBD**  |  **DBD**  |  **DBD**  |     Y     |
| Date of Birth          |  **DBB**  |  **DBB**  |  **DBB**  |  **DBB**  |  **DBB**  |  **DBB**  |  **DBB**  |  **DBB**  |     Y     |
| Gender                 |  **DBC**  |  **DBC**  |  **DBC**  |  **DBC**  |  **DBC**  |  **DBC**  |  **DBC**  |  **DBC**  |     Y     |
| Eye Color              |    DAY    |  **DAY**  |  **DAY**  |  **DAY**  |  **DAY**  |  **DAY**  |  **DAY**  |  **DAY**  |     Y     |
| Height (inches)        |    DAU    |  **DAU**  |  **DAU**  |  **DAU**  |  **DAU**  |  **DAU**  |  **DAU**  |  **DAU**  |     Y     |
| Street Address         |  **DAG**  |  **DAG**  |  **DAG**  |  **DAG**  |  **DAG**  |  **DAG**  |  **DAG**  |  **DAG**  |     Y     |
| City                   |  **DAI**  |  **DAI**  |  **DAI**  |  **DAI**  |  **DAI**  |  **DAI**  |  **DAI**  |  **DAI**  |     Y     |
| State                  |  **DAJ**  |  **DAJ**  |  **DAJ**  |  **DAJ**  |  **DAJ**  |  **DAJ**  |  **DAJ**  |  **DAJ**  |     Y     |
| Postal Code            |  **DAK**  |  **DAK**  |  **DAK**  |  **DAK**  |  **DAK**  |  **DAK**  |  **DAK**  |  **DAK**  |     Y     |
| Customer ID            |  **DBJ**  |  **DAQ**  |  **DAQ**  |  **DAQ**  |  **DAQ**  |  **DAQ**  |  **DAQ**  |  **DAQ**  |     Y     |
| Document ID            |   `--`    |  **DCF**  |  **DCF**  |  **DCF**  |  **DCF**  |  **DCF**  |  **DCF**  |  **DCF**  |     Y     |
| Issuing Country        |   `--`    |  **DCG**  |  **DCG**  |  **DCG**  |  **DCG**  |  **DCG**  |  **DCG**  |  **DCG**  |     Y     |
| Middle Name Truncation |   `--`    |  **DDG**  |   `--`    |  **DDG**  |  **DDG**  |  **DDG**  |  **DDG**  |  **DDG**  |     Y     |
| First Name Truncation  |   `--`    |  **DDF**  |   `--`    |  **DDF**  |  **DDF**  |  **DDF**  |  **DDF**  |  **DDF**  |     Y     |
| Last Name Truncation   |   `--`    |  **DDE**  |   `--`    |  **DDE**  |  **DDE**  |  **DDE**  |  **DDE**  |  **DDE**  |     Y     |
| Second Street Address  |    DAH    |    DAH    |    DAH    |    DAH    |    DAH    |    DAH    |    DAH    |    DAH    |     Y     |
| Hair Color             |    DAZ    |    DAZ    |    DAZ    |    DAZ    |    DAZ    |    DAZ    |    DAZ    |    DAZ    |     Y     |
| Place of Birth         |   `--`    |   `--`    |    DCI    |    DCI    |    DCI    |    DCI    |    DCI    |    DCI    |     Y     |
| Audit Information      |   `--`    |   `--`    |    DCJ    |    DCJ    |    DCJ    |    DCJ    |    DCJ    |    DCJ    |     Y     |
| Inventory Control      |   `--`    |   `--`    |    DCK    |    DCK    |    DCK    |    DCK    |    DCK    |    DCK    |     Y     |
| Last Name Alias        |    DBO    |    DBN    |    DBN    |    DBN    |    DBN    |    DBN    |    DBN    |    DBN    |     Y     |
| First Name Alias       |    DBP    |    DBG    |    DBG    |    DBG    |    DBG    |    DBG    |    DBG    |    DBG    |     Y     |
| Suffix Alias           |    DBR    |   `--`    |    DBS    |    DBS    |    DBS    |    DBS    |    DBS    |    DBS    |     Y     |
| Name Suffix            |    DBN    |  **DCU**  |    DCU    |    DCU    |    DCU    |    DCU    |    DCU    |    DCU    |     Y     |

### Example of a raw driver's license payload

Version 8 Example License Data

```
@

ANSI 636026080102DL00410288ZA03290015DLDAQD12345678
DCSPUBLIC
DDEN
DACJOHN
DDFN
DADJOE
DDGN
DCAD
DCBNONE
DCDNONE
DBD08242015
DBB01311970
DBA01312035
DBC1
DAU069 in
DAYGRN
DAG1234 TEST ST
DAICity
DAJAZ
DAK955530000  
DCF83D9BN217QO983B1
DCGUSA
DAW180
DAZBRO
DCK12345678900000000000
DDB02142014
DDK1
ZAZAAN
ZAB
ZAC
```

# Credits
Credit to [@ksoftllc](https://github.com/ksoftllc) and his Swift library that I used to copy some of the parts that I did not have examples for - https://github.com/ksoftllc/license-parser
