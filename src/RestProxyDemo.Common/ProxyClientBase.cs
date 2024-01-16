using Microsoft.Extensions.Logging;

namespace RestProxyDemo.Common;

public abstract class ProxyClientBase<TClient, TException> : IProxyClient<TClient>
    where TClient : ICommunicationClient
    where TException : Exception, IApiException
{
    public IClientFactory<TClient> ClientFactory { get; private set; }
    private readonly ILogger _logger;

    public ProxyClientBase(IClientFactory<TClient> clientFactory, ILogger logger)
    {
        ClientFactory = clientFactory;
        _logger = logger;
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
            _logger.LogError($"{ex.StatusCode}:{ex.Message}", ex);
            throw new ProxyServiceException(ex.Message, ex);
        }
        catch (Exception ex)
        {
            client.Abort();
            _logger.LogError(ex.Message, ex);
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
            _logger.LogError($"{ex.StatusCode}:{ex.Message}", ex);
            throw new ProxyServiceException(ex.Message);
        }
        catch (Exception ex)
        {
            client.Abort();
            _logger.LogError(ex.Message, ex);
            throw new ProxyServiceException(ex.Message, ex);
        }
    }    
}