using System;

namespace TaskiePet.WebApi.Models.Request;

public class DailyTaskMarkCompletedRequest
{
	public bool IsCompleted { get; set; } = default!;
}
