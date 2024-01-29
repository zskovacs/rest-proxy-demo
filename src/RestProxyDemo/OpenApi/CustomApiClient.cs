namespace RestProxyDemo.Common;

public partial class CustomApiClient<T> : IApiClient
{
    public void Close()
    {
        throw new NotImplementedException();
    }

    public void Abort()
    {
        throw new NotImplementedException();
    }

    public HttpClient HttpClient { get; }
    public ICustomApiClient<Pet> Client => this;
}