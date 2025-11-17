using System;
using Microsoft.EntityFrameworkCore;
using TaskiePet.Application.Repositories.Abstraction;
using TaskiePet.Domain.Entities;
using TaskiePet.Infrastructure.Database;

namespace TaskiePet.Infrastructure.Repositories;

public class DailyTaskRepository(AppDbContext dbContext)
	: GenericRepository<DailyTask>(dbContext), IDailyTaskRepository
{
	public async Task<DailyTask?> GetTaskByIdAsync(Guid taskId)
	{
		return await _dbContext.DailyTasks.FirstOrDefaultAsync(t => t.Id == taskId);
	}

	public async Task<IEnumerable<DailyTask>> GetTasksByUserIdAsync(Guid userId)
	{
		return await _dbContext.DailyTasks
			.Where(t => t.UserId == userId)
			.ToListAsync();
	}
}
