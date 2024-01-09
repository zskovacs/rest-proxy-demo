namespace RestProxyDemo.Common;

public abstract class ApiClientFactory<TClient> : IClientFactory<TClient> where TClient : IApiCommunicationClient
{
    public string BaseUrl { get; }

    protected ApiClientFactory(string baseUrl)
    {
        BaseUrl = baseUrl;
    }

    public abstract TClient CreateClient();
}