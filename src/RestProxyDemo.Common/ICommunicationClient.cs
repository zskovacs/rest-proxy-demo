namespace RestProxyDemo.Common;

public interface ICommunicationClient
{
    void Close();
    void Abort();
}