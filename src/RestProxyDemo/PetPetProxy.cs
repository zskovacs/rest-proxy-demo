using RestProxyDemo.Converters;

namespace RestProxyDemo;

public class PetPetProxy : IPetProxy
{ 
    internal IProxyClient<IApiClient> Client { get; }

    public PetPetProxy(IProxyClient<IApiClient> client)
    {
        Client = client;
    }
    
    public async Task Create(CreatePetRequest petRequest, CancellationToken cancellationToken = default)
    {
        var request = petRequest.Convert();
        Task clientCall(IApiClient c) => c.Client.AddPetAsync(request, cancellationToken);
        await Client.CallClientMethod(clientCall).ConfigureAwait(false);
    }

    public async Task<IPet> GetPetByIdAsync(long petId, CancellationToken cancellationToken = default)
    {
        Task<Pet> clientCall(IApiClient c) => c.Client.GetPetByIdAsync(petId, cancellationToken);

        var response = await Client.CallClientMethod(clientCall).ConfigureAwait(false);

        return response;
    }
}