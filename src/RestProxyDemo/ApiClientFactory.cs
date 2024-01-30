using System.Net.Http.Headers;
using Microsoft.Extensions.Logging;

namespace RestProxyDemo;

internal class ApiClientFactory : ApiClientFactory<IApiClient>
{
    private readonly string _authToken;
    private readonly ILogger _logger;

    public ApiClientFactory(string baseUrl, string authToken, ILogger logger) : base(baseUrl)
    {
        _authToken = authToken;
        _logger = logger;
    }
    
    public override IApiClient CreateClient()
    {
        var httpClient = new HttpClient();
        //ADD CorrelationHeader
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _authToken);

        return new CustomPetApiClient(httpClient, BaseUrl, _logger);
    }
}