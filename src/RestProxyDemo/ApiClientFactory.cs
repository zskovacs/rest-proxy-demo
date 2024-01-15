using System.Net.Http.Headers;

namespace RestProxyDemo;

internal class ApiClientFactory(string baseUrl, string authToken) : ApiClientFactory<IApiClient>(baseUrl)
{
    public override IApiClient CreateClient()
    {
        var httpClient = new HttpClient();
        //ADD CorrelationHeader
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);

        return new RestProxyDemoApiClient(httpClient, BaseUrl);
    }
}