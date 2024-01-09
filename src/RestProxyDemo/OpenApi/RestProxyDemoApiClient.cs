namespace RestProxyDemo.OpenApi;

internal partial class RestProxyDemoApiClient : IApiClient
{
    public HttpClient HttpClient => _httpClient;

    public IRestProxyDemoApiClient Client => this;

    public void Close() => HttpClient?.Dispose();

    public void Abort() => HttpClient?.Dispose();
}