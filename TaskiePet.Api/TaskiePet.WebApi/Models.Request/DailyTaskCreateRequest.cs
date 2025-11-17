using System;

namespace TaskiePet.WebApi.Models.Request;

public class DailyTaskCreateRequest
{
	public string Title { get; set; } = default!;
	public string Description { get; set; } = default!;
	public bool IsCompleted { get; set; } = false;
}
