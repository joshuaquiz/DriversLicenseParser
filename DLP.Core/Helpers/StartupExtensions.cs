using DLP.Core.Interfaces;
using DLP.Core.ParseableLicenses;
using Microsoft.Extensions.DependencyInjection;

namespace DLP.Core.Helpers;

/// <summary>
/// Startup extensions.
/// </summary>
public static class StartupExtensions
{
    /// <summary>
    /// Adds <see cref="IDriversLicenseParser"/> and its dependencies to the tree.
    /// </summary>
    /// <param name="provider"></param>
    /// <returns></returns>
    public static IServiceCollection AddDriversLicenseParsing(this IServiceCollection provider) =>
        provider
            .AddSingleton<IParseableLicense, Alabama>()
            .AddSingleton<IParseableLicense, Alaska>()
            .AddSingleton<IParseableLicense, Alberta>()
            .AddSingleton<IParseableLicense, AmericanSamoa>()
            .AddSingleton<IParseableLicense, Arizona>()
            .AddSingleton<IParseableLicense, Arkansas>()
            .AddSingleton<IParseableLicense, BritishColumbia>()
            .AddSingleton<IParseableLicense, California>()
            .AddSingleton<IParseableLicense, Coahuila>()
            .AddSingleton<IParseableLicense, Colorado>()
            .AddSingleton<IParseableLicense, Connecticut>()
            .AddSingleton<IParseableLicense, Delaware>()
            .AddSingleton<IParseableLicense, DistrictOfColumbia>()
            .AddSingleton<IParseableLicense, Florida>()
            .AddSingleton<IParseableLicense, Georgia>()
            .AddSingleton<IParseableLicense, Guam>()
            .AddSingleton<IParseableLicense, Hawaii>()
            .AddSingleton<IParseableLicense, Hidalgo>()
            .AddSingleton<IParseableLicense, Idaho>()
            .AddSingleton<IParseableLicense, Illinois>()
            .AddSingleton<IParseableLicense, Indiana>()
            .AddSingleton<IParseableLicense, Iowa>()
            .AddSingleton<IParseableLicense, Kansas>()
            .AddSingleton<IParseableLicense, Kentucky>()
            .AddSingleton<IParseableLicense, Louisiana>()
            .AddSingleton<IParseableLicense, Maine>()
            .AddSingleton<IParseableLicense, Manitoba>()
            .AddSingleton<IParseableLicense, Maryland>()
            .AddSingleton<IParseableLicense, Massachusetts>()
            .AddSingleton<IParseableLicense, Michigan>()
            .AddSingleton<IParseableLicense, Minnesota>()
            .AddSingleton<IParseableLicense, Mississippi>()
            .AddSingleton<IParseableLicense, Missouri>()
            .AddSingleton<IParseableLicense, Montana>()
            .AddSingleton<IParseableLicense, Nebraska>()
            .AddSingleton<IParseableLicense, Nevada>()
            .AddSingleton<IParseableLicense, NewBrunswick>()
            .AddSingleton<IParseableLicense, NewfoundlandAndLabrador>()
            .AddSingleton<IParseableLicense, NewHampshire>()
            .AddSingleton<IParseableLicense, NewJersey>()
            .AddSingleton<IParseableLicense, NewMexico>()
            .AddSingleton<IParseableLicense, NewYork>()
            .AddSingleton<IParseableLicense, NorthCarolina>()
            .AddSingleton<IParseableLicense, NorthDakota>()
            .AddSingleton<IParseableLicense, NorthernMariannaIslands>()
            .AddSingleton<IParseableLicense, NovaScotia>()
            .AddSingleton<IParseableLicense, Nunavut>()
            .AddSingleton<IParseableLicense, Ohio>()
            .AddSingleton<IParseableLicense, Oklahoma>()
            .AddSingleton<IParseableLicense, Ontario>()
            .AddSingleton<IParseableLicense, Oregon>()
            .AddSingleton<IParseableLicense, Pennsylvania>()
            .AddSingleton<IParseableLicense, PrinceEdwardIsland>()
            .AddSingleton<IParseableLicense, PuertoRico>()
            .AddSingleton<IParseableLicense, Quebec>()
            .AddSingleton<IParseableLicense, RhodeIsland>()
            .AddSingleton<IParseableLicense, Saskatchewan>()
            .AddSingleton<IParseableLicense, SouthCarolina>()
            .AddSingleton<IParseableLicense, SouthDakota>()
            .AddSingleton<IParseableLicense, StateDeptDiplomatic>()
            .AddSingleton<IParseableLicense, Tennessee>()
            .AddSingleton<IParseableLicense, Texas>()
            .AddSingleton<IParseableLicense, Utah>()
            .AddSingleton<IParseableLicense, Vermont>()
            .AddSingleton<IParseableLicense, Virginia>()
            .AddSingleton<IParseableLicense, VirginIslands>()
            .AddSingleton<IParseableLicense, Washington>()
            .AddSingleton<IParseableLicense, WestVirginia>()
            .AddSingleton<IParseableLicense, Wisconsin>()
            .AddSingleton<IParseableLicense, Wyoming>()
            .AddSingleton<IParseableLicense, Yukon>()
            .AddSingleton<IDriversLicenseParser, DriversLicenseParser>();
}