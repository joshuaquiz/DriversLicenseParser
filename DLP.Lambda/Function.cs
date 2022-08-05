using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using Amazon.Lambda.Serialization.SystemTextJson;
using DLP.Core.Helpers;
using DLP.Core.Interfaces;
using DLP.Lambda;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System.Net;
using System.Text.Json.Serialization;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(SourceGeneratorLambdaJsonSerializer<HttpApiJsonSerializerContext>))]

namespace DLP.Lambda;

[JsonSerializable(typeof(APIGatewayHttpApiV2ProxyRequest))]
[JsonSerializable(typeof(APIGatewayHttpApiV2ProxyResponse))]
public partial class HttpApiJsonSerializerContext : JsonSerializerContext
{
}

public sealed class Function
{
    private readonly IServiceProvider _serviceProvider;

    public Function()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddDriversLicenseParsing();
        _serviceProvider = serviceCollection.BuildServiceProvider();
    }

    public APIGatewayHttpApiV2ProxyResponse Post(
        APIGatewayHttpApiV2ProxyRequest request,
        ILambdaContext context) =>
        new()
        {
            StatusCode = (int)HttpStatusCode.OK,
            Body = JsonConvert.SerializeObject(
                _serviceProvider.GetRequiredService<IDriversLicenseParser>()
                    .Parse(
                        request.Body)),
            Headers = new Dictionary<string, string> {{"Content-Type", "application/json"}}
        };
}