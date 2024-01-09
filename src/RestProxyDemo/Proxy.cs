namespace RestProxyDemo;

public class Proxy : IProxy
{
    internal IProxyClient<IApiClient> Client { get; }

    public Proxy(IProxyClient<IApiClient> client)
    {
        Client = client;
    }
    
    
        
    public Task<Result> Create(CreateRequest request, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}