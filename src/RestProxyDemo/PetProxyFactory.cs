namespace RestProxyDemo;

public class PetProxyFactory : IPetProxyFactory
{
    private readonly IProxyClient<IApiClient> _apiClient;
    public PetProxyFactory(string baseUrl)
    {
        var clientFactory = new ApiClientFactory(baseUrl);
        _apiClient = new ProxyClient(clientFactory);
    }
    public IPetProxy Create()
    {
        
        return new PetPetProxy(_apiClient);
    }
}