namespace RestProxyDemo.Common;

public interface ICustomApiClient<T>
{
    Task<T> Get(string url, CancellationToken cancellationToken);
    Task<T> Get(string url);
    
    Task<ICollection<T>> GetAll(string url, CancellationToken cancellationToken);
    Task<ICollection<T>> GetAll(string url);
    
    Task Put(string url, T request, CancellationToken cancellationToken);
    Task Put(string url, T request);
    
    Task Post(string url, T request, CancellationToken cancellationToken);
    Task Post(string url, T request);
    
    Task Delete(string url, CancellationToken cancellationToken);
    Task Delete(string url);
}