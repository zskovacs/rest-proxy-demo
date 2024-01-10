namespace RestProxyDemo.Abstract;

public interface IProxy
{
    Task Create(CreatePetRequest petRequest, CancellationToken cancellationToken = default);
    Task<IPet> GetPetByIdAsync(long petId, CancellationToken cancellationToken = default);
}