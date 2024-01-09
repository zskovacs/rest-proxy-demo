namespace RestProxyDemo.Common;

public interface IClientFactory<out T> where T : ICommunicationClient
{
    T CreateClient();
}