using System;
using TaskiePet.Application.Common;
using TaskiePet.Application.Constants;
using TaskiePet.Application.DTOs;
using TaskiePet.Application.Repositories.Abstraction;
using TaskiePet.Application.Services.Abstraction;
using TaskiePet.Domain.Entities;

namespace TaskiePet.Application.Services;

public class DailyTaskService(
	IDailyTaskRepository _dailyTaskRepository) : IDailyTaskService
{
	public async Task<DailyTask> CreateDailyTaskAsync(DailyTaskCreateDto dto)
	{
		// todo: get current user id from context

		// map DTO to entity
		var taskEntity = new DailyTask
		{
			UserId = dto.UserId,
			Title = dto.Title,
			Description = dto.Description,
			IsCompleted = false
		};
		await _dailyTaskRepository.AddAsync(taskEntity);
		return taskEntity;
	}

	public async Task<DailyTask?> GetDailyTaskAsync(Guid id)
		=> await _dailyTaskRepository.GetTaskByIdAsync(id);

	public async Task<IEnumerable<DailyTask>> GetDailyTasksByUserIdAsync(Guid userId)
		=> await _dailyTaskRepository.GetTasksByUserIdAsync(userId);

	public async Task<DailyTask?> SetTaskCompletionStatusAsync(Guid taskId, bool isCompleted)
	{
		var updatingTask = await _dailyTaskRepository.GetTaskByIdAsync(taskId);
		if (updatingTask == null)
		{
			throw new KeyNotFoundException(ErrorMessages.DailyTaskNotFound);
		}

		// map DTO to entity
		updatingTask.IsCompleted = isCompleted;
		updatingTask.CompletedAt = isCompleted ? DateTime.UtcNow : null;

		_dailyTaskRepository.Update(updatingTask);

		return updatingTask;
	}

	public async Task<DailyTask?> UpdateDailyTaskAsync(Guid taskId, DailyTaskUpdateDto dto)
	{
		var updatingTask = await _dailyTaskRepository.GetTaskByIdAsync(taskId);
		if (updatingTask == null)
		{
			throw new KeyNotFoundException(ErrorMessages.DailyTaskNotFound);
		}

		// map DTO to entity
		updatingTask.Title = dto.Title ?? updatingTask.Title;
		updatingTask.Description = dto.Description ?? updatingTask.Description;
		updatingTask.IsCompleted = dto.IsCompleted;
		updatingTask.CompletedAt = dto.IsCompleted ? DateTime.UtcNow : null;

		_dailyTaskRepository.Update(updatingTask);

		return updatingTask;
	}
}
