using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace RestProxyDemo.OpenApi;

internal partial class RestProxyDemoApiClient : IApiClient
{
    private readonly ILogger _logger;

    public RestProxyDemoApiClient(HttpClient httpClient, string baseUrl, ILogger logger) : this(httpClient)
    {
        _logger = logger;
        BaseUrl = baseUrl;
    }
    public HttpClient HttpClient => _httpClient;

    public IRestProxyDemoApiClient Client => this;

    public void Close() => HttpClient?.Dispose();

    public void Abort() => HttpClient?.Dispose();

    partial void PrepareRequest(HttpClient client, HttpRequestMessage request, string url) => _logger.LogDebug($"SENDING to {url}: {JsonConvert.SerializeObject(request)}");
    partial void ProcessResponse(HttpClient client, HttpResponseMessage response) => _logger.LogDebug($"RECEIVED: {JsonConvert.SerializeObject(response)}");


}