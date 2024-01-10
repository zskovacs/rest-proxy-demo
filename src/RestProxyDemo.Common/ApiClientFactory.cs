﻿namespace RestProxyDemo.Common;

public abstract class ApiClientFactory<TClient>(string baseUrl) : IClientFactory<TClient>
    where TClient : IApiCommunicationClient
{
    public string BaseUrl { get; } = baseUrl;

    public abstract TClient CreateClient();
}