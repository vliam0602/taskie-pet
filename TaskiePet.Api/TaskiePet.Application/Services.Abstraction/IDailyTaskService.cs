using System;
using TaskiePet.Application.DTOs;
using TaskiePet.Domain.Entities;

namespace TaskiePet.Application.Services.Abstraction;

public interface IDailyTaskService
{
	Task<DailyTask?> GetDailyTaskAsync(Guid id);
	Task<IEnumerable<DailyTask>> GetDailyTasksByUserIdAsync(Guid userId);
	Task<DailyTask> CreateDailyTaskAsync(DailyTaskCreateDto dto);
	Task<DailyTask?> UpdateDailyTaskAsync(Guid taskId, DailyTaskUpdateDto dto);
	Task<DailyTask?> SetTaskCompletionStatusAsync(Guid taskId, bool isCompleted);
}
