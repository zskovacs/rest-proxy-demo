namespace RestProxyDemo.Abstract.Response;

public interface IPet
{
     ICategory PetCategory { get; }
     string Name { get; }
     System.Collections.Generic.ICollection<string> PhotoUrls { get; }
     System.Collections.Generic.ICollection<ITag> PetTags { get; }
     Status? PetStatus { get; }
} 