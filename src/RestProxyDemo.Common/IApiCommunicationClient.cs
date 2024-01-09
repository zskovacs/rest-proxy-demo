namespace RestProxyDemo.Common;

public interface IApiCommunicationClient<out T> : IApiCommunicationClient
{
    T Client { get; }
}

public interface IApiCommunicationClient : ICommunicationClient
{
    HttpClient HttpClient { get; }
}