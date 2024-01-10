namespace RestProxyDemo.Converters;

public static class CreatePetRequestConverter
{
    public static Pet Convert(this CreatePetRequest request)
    {
        return new Pet();
    }
}