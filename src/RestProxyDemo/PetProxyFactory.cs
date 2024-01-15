namespace RestProxyDemo;

public class PetProxyFactory : IPetProxyFactory
{
    private readonly IProxyClient<IApiClient> _apiClient;
    public PetProxyFactory(string baseUrl, string authToken)
    {
        var clientFactory = new ApiClientFactory(baseUrl, authToken);
        _apiClient = new ProxyClient(clientFactory);
    }
    public IPetProxy Create()
    {
        
        return new PetPetProxy(_apiClient);
    }
}