namespace RestProxyDemo;

internal class ApiClientFactory(string baseUrl) : ApiClientFactory<IApiClient>(baseUrl)
{
    public override IApiClient CreateClient()
    {
        var httpClient = new HttpClient();
        //ADD CorrelationHeader

        return new RestProxyDemoApiClient(httpClient, BaseUrl);
    }
}