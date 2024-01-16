using Microsoft.Extensions.Logging;

namespace RestProxyDemo;

public class ProxyClient : ProxyClientBase<IApiClient, Common.ApiException>
{
    public ProxyClient(IClientFactory<IApiClient> clientFactory, ILogger logger) : base(clientFactory, logger)
    {
        
    }
}