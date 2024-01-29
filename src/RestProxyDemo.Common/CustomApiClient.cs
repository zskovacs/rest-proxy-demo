using Newtonsoft.Json;

namespace RestProxyDemo.Common;

public class CustomApiClient<T> : ICustomApiClient<T>
{
    public string BaseUrl { get; set; }
    public CustomApiClient(HttpClient httpClient, string baseUrl)
    {
        HttpClient = httpClient;
        BaseUrl = baseUrl;
    }
    public async Task<T> Get(string url)
    {
        return JsonConvert.DeserializeObject<T>(await HttpClient.GetStringAsync(BaseUrl + url));
    }

    public Task<ICollection<T>> GetAll(string url, string order)
    {
        throw new NotImplementedException();
    }
    
    public Task Put(string url, T request)
    {
        throw new NotImplementedException();
    }

    public Task Post(string url, T request)
    {
        throw new NotImplementedException();
    }

    public Task Delete(string url)
    {
        throw new NotImplementedException();
    }
    
    public void Close() => HttpClient?.Dispose();

    public void Abort() => HttpClient?.Dispose();

    public HttpClient HttpClient { get; }
}