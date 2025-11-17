using System;

namespace TaskiePet.Application.DTOs;

public class DailyTaskCreateDto
{
	public Guid UserId { get; set; }
	public string Title { get; set; } = default!;
	public string Description { get; set; } = default!;
	public bool IsCompleted { get; set; } = default!;
	public DateTime? CompletedAt { get; set; } = null;
}
