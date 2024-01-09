namespace RestProxyDemo.Common;

public interface IProxyClient<TClient> where TClient : ICommunicationClient
{
    IClientFactory<TClient> ClientFactory { get; }

    Task<T> CallClientMethod<T>(Func<TClient, Task<T>> clientAction);
    Task CallVoidClientMethod(Func<TClient, Task> clientAction);
}