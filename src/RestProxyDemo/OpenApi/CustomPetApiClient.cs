using System.Text;
using Microsoft.Extensions.Logging;

namespace RestProxyDemo.OpenApi;

public class CustomPetApiClient : CustomApiClient<Pet>, IApiClient
{
    private readonly ILogger _logger;
    
    public CustomPetApiClient(HttpClient httpClient, string baseUrl, ILogger logger) : base(httpClient, baseUrl)
    {
        _logger = logger;
    }
    public ICustomApiClient<Pet> Client => this;
    
    protected override void PrepareRequest(HttpClient client, HttpRequestMessage request, string url) => _logger.LogDebug($"SENDING to {url}:");
    protected override void PrepareRequest(HttpClient client, HttpRequestMessage request, StringBuilder urlBuilder) => _logger.LogDebug($"SENDING to");
    protected override void ProcessResponse(HttpClient client, HttpResponseMessage response) => _logger.LogDebug($"RECEIVED:");
}