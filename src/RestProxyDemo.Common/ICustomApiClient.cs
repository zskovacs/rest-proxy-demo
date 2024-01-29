namespace RestProxyDemo.Common;

public interface ICustomApiClient<T>
{
    Task<T> Get(string url);
    Task Put(string url, T request);
    Task Post(string url, T request);
    Task Delete(string url);
}