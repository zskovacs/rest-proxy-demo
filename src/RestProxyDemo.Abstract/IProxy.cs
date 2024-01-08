namespace RestProxyDemo.Abstract;

public interface IProxy
{
    Task<Result> Create(CreateRequest request, CancellationToken cancellationToken = default);
}