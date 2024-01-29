using System.Runtime.InteropServices.ComTypes;

namespace RestProxyDemo.OpenApi;

public partial class Pet : IPet
{
    public ICategory PetCategory { get; }
    public string Name { get; }
    public ICollection<string> PhotoUrls { get; }
    public ICollection<ITag> PetTags { get; }
    public Status? PetStatus { get; }
}