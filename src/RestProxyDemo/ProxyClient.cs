namespace RestProxyDemo;

public class ProxyClient(IClientFactory<IApiClient> clientFactory) : ProxyClientBase<IApiClient, ApiException>(clientFactory);