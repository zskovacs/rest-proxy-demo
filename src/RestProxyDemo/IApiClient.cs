namespace RestProxyDemo;

public interface IApiClient : IApiCommunicationClient<ICustomApiClient<Pet>>
{
    
}