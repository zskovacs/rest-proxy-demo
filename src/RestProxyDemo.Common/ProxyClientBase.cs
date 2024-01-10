namespace RestProxyDemo.Common;

public abstract class ProxyClientBase<TClient, TException>(IClientFactory<TClient> clientFactory) : IProxyClient<TClient>
    where TClient : ICommunicationClient
    where TException : Exception
{
    public IClientFactory<TClient> ClientFactory { get; private set; } = clientFactory;

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

    public async Task CallVoidClientMethod(Func<TClient, Task> clientAction)
    {
        TClient client = ClientFactory.CreateClient();
        try
        {
            await clientAction(client).ConfigureAwait(continueOnCapturedContext: false);
            client.Close();
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
}