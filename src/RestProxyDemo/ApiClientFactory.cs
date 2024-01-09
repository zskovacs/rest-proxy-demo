namespace RestProxyDemo;

internal class ApiClientFactory : ApiClientFactory<IApiClient>
{
    public ApiClientFactory(string baseUrl) : base(baseUrl)
    {
    }
    
    public override IApiClient CreateClient()
    {
        var httpClient = new HttpClient();
        //ADD CorrelationHeader

        return new RestProxyDemoApiClient(httpClient);
    }


}