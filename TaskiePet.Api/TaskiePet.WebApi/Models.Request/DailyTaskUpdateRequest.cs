using System;

namespace TaskiePet.WebApi.Models.Request;

public class DailyTaskUpdateRequest
{
	public string Title { get; set; } = default!;
	public string Description { get; set; } = default!;
	public bool IsCompleted { get; set; } = default!;
}
