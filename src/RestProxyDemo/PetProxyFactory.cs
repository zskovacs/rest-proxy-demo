using Microsoft.Extensions.Logging;

namespace RestProxyDemo;

public class PetProxyFactory : IPetProxyFactory
{
    private readonly IProxyClient<IApiClient> _apiClient;
    public PetProxyFactory(string baseUrl, string authToken, ILogger logger)
    {
        var clientFactory = new ApiClientFactory(baseUrl, authToken, logger);
        _apiClient = new ProxyClient(clientFactory, logger);
    }
    public IPetProxy Create()
    {
        return new PetPetProxy(_apiClient);
    }
}