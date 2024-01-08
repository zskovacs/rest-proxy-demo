namespace RestProxyDemo;

public class ProxyFactory : IProxyFactory
{
    
    public IProxy Create()
    {
        return new Proxy();
    }
}