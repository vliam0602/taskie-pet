using System;
using TaskiePet.Domain.Entities;

namespace TaskiePet.Application.Repositories.Abstraction;

public interface IDailyTaskRepository : IGenericRepository<DailyTask>
{
	Task<IEnumerable<DailyTask>> GetTasksByUserIdAsync(Guid userId);
	Task<DailyTask?> GetTaskByIdAsync(Guid taskId);
}
