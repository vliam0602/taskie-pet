using System.ComponentModel.DataAnnotations;

namespace TaskiePet.Domain.Common;

public class BaseEntity
{
    [Key]
    public Guid Id { get; set; } = NewGuid.Next();
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}