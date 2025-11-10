namespace TaskiePet.Domain.Common;

public static class NewGuid
{
    public static Guid Next()
    {
        return Guid.CreateVersion7();
    }
}
