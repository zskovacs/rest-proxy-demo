namespace RestProxyDemo.OpenApi;

public class CustomPetApiClient : CustomApiClient<Pet>, IApiClient
{
    public CustomPetApiClient(HttpClient httpClient, string baseUrl) : base(httpClient, baseUrl)
    {
        
    }
    public ICustomApiClient<Pet> Client => this;
}