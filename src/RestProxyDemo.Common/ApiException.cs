﻿namespace RestProxyDemo.Common;

public class ApiException : Exception, IApiException
{
    public int StatusCode { get; private set; }

    public string Response { get; private set; }

    public System.Collections.Generic.IReadOnlyDictionary<string, System.Collections.Generic.IEnumerable<string>> Headers { get; private set; }

    public ApiException(string message, int statusCode, string response, System.Collections.Generic.IReadOnlyDictionary<string, System.Collections.Generic.IEnumerable<string>> headers, System.Exception innerException)
        : base(message + "\n\nStatus: " + statusCode + "\nResponse: \n" + ((response == null) ? "(null)" : response.Substring(0, response.Length >= 512 ? 512 : response.Length)), innerException)
    {
        StatusCode = statusCode;
        Response = response;
        Headers = headers;
    }

    public override string ToString()
    {
        return $"HTTP Response: \n\n{Response}\n\n{base.ToString()}";
    }
}