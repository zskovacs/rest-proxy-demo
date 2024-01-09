namespace RestProxyDemo;

public class ProxyClient : ProxyClientBase<IApiClient, ApiException>
{
    public ProxyClient(IClientFactory<IApiClient> clientFactory) : base(clientFactory)
    {
        
    }
}