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
        Task clientCall(IApiClient c) => c.Client.Post("/petstore/create", request);
        await Client.CallClientMethod(clientCall).ConfigureAwait(false);
    }

    public async Task<IPet> GetPetByIdAsync(long petId, CancellationToken cancellationToken = default)
    {
        Task<Pet> clientCall(IApiClient c) => c.Client.Get("/petstore?page=10&localized=true");

        var response = await Client.CallClientMethod(clientCall).ConfigureAwait(false);

        return response;
    }
}