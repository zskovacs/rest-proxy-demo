namespace RestProxyDemo;

public class ProxyFactory : IProxyFactory
{
    private readonly IProxyClient<IApiClient> _apiClient;
    public ProxyFactory(string baseUrl)
    {
        var clientFactory = new ApiClientFactory(baseUrl);
        _apiClient = new ProxyClient(clientFactory);
    }
    public IProxy Create()
    {
        return new Proxy(_apiClient);
    }
}