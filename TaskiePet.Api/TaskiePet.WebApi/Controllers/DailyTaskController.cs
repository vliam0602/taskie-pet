using Microsoft.AspNetCore.Mvc;
using TaskiePet.Application.DTOs;
using TaskiePet.Application.Services.Abstraction;
using TaskiePet.Domain.Entities;
using TaskiePet.WebApi.Models.Request;
using TaskiePet.WebApi.Models.Response;

namespace TaskiePet.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DailyTaskController(IDailyTaskService _dailyTaskService) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ApiResponse<DailyTask>), StatusCodes.Status201Created)]
    public async Task<ActionResult<ApiResponse<DailyTask>>> CreateDailyTask([FromBody] DailyTaskCreateRequest request)
    {
        var taskDto = new DailyTaskCreateDto
        {
            UserId = Guid.Parse("019a6d2f-5e4a-713f-8ff5-6b87315cc15b"), // default user Id
            Title = request.Title,
            Description = request.Description,
            IsCompleted = request.IsCompleted
        };
        var createdTask = await _dailyTaskService.CreateDailyTaskAsync(taskDto);
        return CreatedAtAction(nameof(CreateDailyTask),
            new { taskId = createdTask.Id }, new ApiResponse<DailyTask> { Data = createdTask });
    }

    [HttpPut("{taskId}")]
    [ProducesResponseType(typeof(ApiResponse<DailyTask>), StatusCodes.Status200OK)]
    public async Task<ActionResult<ApiResponse<DailyTask>>> UpdateDailyTaskInformation(Guid taskId, [FromBody] DailyTaskUpdateRequest request)
    {
        var taskDto = new DailyTaskUpdateDto
        {
            Title = request.Title,
            Description = request.Description,
            IsCompleted = request.IsCompleted
        };
        var updatedTask = await _dailyTaskService.UpdateDailyTaskAsync(taskId, taskDto);
        return Ok(new ApiResponse<DailyTask> { Data = updatedTask });
    }

    [HttpPut("mark-completed/{taskId}")]
    [ProducesResponseType(typeof(ApiResponse<DailyTask>), StatusCodes.Status200OK)]
    public async Task<ActionResult<ApiResponse<DailyTask>>> MarkDailyTaskCompleted(Guid taskId, [FromBody] DailyTaskMarkCompletedRequest request)
    {
        var updatedTask = await _dailyTaskService
            .SetTaskCompletionStatusAsync(taskId, request.IsCompleted);

        return Ok(new ApiResponse<DailyTask> { Data = updatedTask });
    }

    [HttpGet("{taskId}")]
    [ProducesResponseType(typeof(ApiResponse<DailyTask>), StatusCodes.Status200OK)]
    public async Task<ActionResult<ApiResponse<DailyTask>>> GetDailyTaskDetail(Guid taskId)
    {
        var taskDetail = await _dailyTaskService.GetDailyTaskAsync(taskId);
        return Ok(new ApiResponse<DailyTask> { Data = taskDetail });
    }

    [HttpGet]
    [ProducesResponseType(typeof(ApiResponse<IEnumerable<DailyTask>>), StatusCodes.Status200OK)]
    public async Task<ActionResult<ApiResponse<IEnumerable<DailyTask>>>> GetDailyTaskListByUser([FromQuery] Guid userId)
    {
        var taskList = await _dailyTaskService.GetDailyTasksByUserIdAsync(userId);
        return Ok(new ApiResponse<IEnumerable<DailyTask>> { Data = taskList });
    }
}