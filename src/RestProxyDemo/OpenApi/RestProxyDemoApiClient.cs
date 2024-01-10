namespace RestProxyDemo.OpenApi;

internal partial class RestProxyDemoApiClient : IApiClient
{
    
    public RestProxyDemoApiClient(HttpClient httpClient, string baseUrl) : this(httpClient)
    {
        BaseUrl = baseUrl;
    }
    public HttpClient HttpClient => _httpClient;

    public IRestProxyDemoApiClient Client => this;

    public void Close() => HttpClient?.Dispose();

    public void Abort() => HttpClient?.Dispose();
}