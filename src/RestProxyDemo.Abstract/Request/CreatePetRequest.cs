namespace RestProxyDemo.Abstract.Request;

public class CreatePetRequest
{
    public KeyValueRequest Category { get; set; }
    public string Name { get; set; }
    public ICollection<string> PhotoUrls { get; set; }
    public ICollection<KeyValueRequest> Tags { get; set; }
    public Status? Status { get; set; }
}