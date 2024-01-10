using System.Runtime.InteropServices.ComTypes;

namespace RestProxyDemo.OpenApi;

public partial class Pet : IPet
{
    public ICategory PetCategory => Category;
    public ICollection<ITag> PetTags => Tags.OfType<ITag>().ToList();
    public Status? PetStatus => (Status?)Status;
}