using TaskiePet.Domain.Common;

namespace TaskiePet.Domain.Entities;

public class User : BaseEntity
{
    public string Email { get; set; } = default!;
    public string PasswordHash { get; set; } = "";
}