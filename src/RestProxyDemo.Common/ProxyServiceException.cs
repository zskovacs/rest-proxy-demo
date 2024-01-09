namespace RestProxyDemo.Common;

public class ProxyServiceException : Exception
{
    public ProxyServiceException()
    {
        
    }

    public ProxyServiceException(string message) : base(message)
    {
        
    }

    public ProxyServiceException(string message, Exception innerException) : base(message, innerException)
    {
        
    }
}