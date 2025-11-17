using System;
using TaskiePet.Domain.Common;

namespace TaskiePet.Domain.Entities;

public class DailyTask : BaseEntity
{
	public Guid UserId { get; set; }
	public string Title { get; set; } = default!;
	public string Description { get; set; } = default!;
	public bool IsCompleted { get; set; } = default!;
	public DateTime? CompletedAt { get; set; } = null;
}
