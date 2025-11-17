using System;

namespace TaskiePet.Application.DTOs;

public class DailyTaskUpdateDto
{
	public string? Title { get; set; }
	public string? Description { get; set; }
	public bool IsCompleted { get; set; } = default!;
	public DateTime? CompletedAt { get; set; } = null;
}
