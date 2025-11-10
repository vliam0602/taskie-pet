using System.ComponentModel.DataAnnotations;

namespace TaskiePet.Domain.Common;

public class BaseEntity
{
    [Key]
    public Guid Id { get; set; } = NewGuid.Next();
    public Guid? CreatedBy { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public Guid? LastModifiedBy { get; set; }
    public DateTime LastModifiedDate { get; set; } = DateTime.UtcNow;
}