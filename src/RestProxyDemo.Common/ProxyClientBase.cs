namespace RestProxyDemo.Common;

public abstract class ProxyClientBase<TClient, TException> : IProxyClient<TClient> where TClient : ICommunicationClient where TException : Exception
{
    public IClientFactory<TClient> ClientFactory { get; private set; }
    public ProxyClientBase(IClientFactory<TClient> clientFactory)
    {
        ClientFactory = clientFactory;
    }
    
    public async Task<T> CallClientMethod<T>(Func<TClient, Task<T>> clientAction)
    {
        TClient client = ClientFactory.CreateClient();
        try
        {
            T result = await clientAction(client).ConfigureAwait(continueOnCapturedContext: false);
            client.Close();
            return result;
        }
        catch (ProxyServiceException)
        {
            throw;
        }
        catch (TException ex)
        {
            client.Abort();
            // LOGGING
            throw new ProxyServiceException(ex.Message);
        }
        catch (Exception ex)
        {
            client.Abort();
            // LOGGING
            throw new ProxyServiceException(ex.Message, ex);
        }
    }

    public Task CallVoidClientMethod(Func<TClient, Task> clientAction)
    {
        throw new NotImplementedException();
    }    
}