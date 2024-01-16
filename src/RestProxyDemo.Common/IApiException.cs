namespace RestProxyDemo.Common;

public interface IApiException
{
    int StatusCode { get; }
    string Response { get; }
}