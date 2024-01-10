using RestProxyDemo.Converters;

namespace RestProxyDemo;

public class Proxy : IProxy
{
    internal IProxyClient<IApiClient> Client { get; }

    public Proxy(IProxyClient<IApiClient> client)
    {
        Client = client;
    }

    public async Task Create(CreatePetRequest petRequest, CancellationToken cancellationToken = default)
    {
        var request = petRequest.Convert();
        Task clientCall(IApiClient c) => c.Client.AddPetAsync(request, cancellationToken);
        await Client.CallVoidClientMethod(clientCall).ConfigureAwait(false);
    }

    public async Task<IPet> GetPetByIdAsync(long petId, CancellationToken cancellationToken = default)
    {
        Task<Pet> clientCall(IApiClient c) => c.Client.GetPetByIdAsync(petId, cancellationToken);

        var response = await Client.CallClientMethod(clientCall).ConfigureAwait(false);

        return response;
    }
}