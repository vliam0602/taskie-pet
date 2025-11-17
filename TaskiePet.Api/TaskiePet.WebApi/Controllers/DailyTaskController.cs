using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskiePet.Application.DTOs;
using TaskiePet.Application.Services.Abstraction;
using TaskiePet.WebApi.Models.Request;

namespace TaskiePet.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DailyTaskController(IDailyTaskService _dailyTaskService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateDailyTask([FromBody] DailyTaskCreateRequest request)
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
            new { taskId = createdTask.Id }, createdTask);
    }

    [HttpPut("{taskId}")]
    public IActionResult UpdateDailyTaskInformation(Guid taskId, [FromBody] DailyTaskUpdateRequest request)
    {
        var taskDto = new DailyTaskUpdateDto
        {
            Title = request.Title,
            Description = request.Description,
            IsCompleted = request.IsCompleted
        };
        var updatedTask = _dailyTaskService.UpdateDailyTaskAsync(taskId, taskDto);
        return Ok(updatedTask);
    }

    [HttpPut("mark-completed/{taskId}")]
    public async Task<IActionResult> MarkDailyTaskCompleted(Guid taskId, [FromBody] DailyTaskMarkCompletedRequest request)
    {
        var updatedTask = await _dailyTaskService
            .SetTaskCompletionStatusAsync(taskId, request.IsCompleted);

        return Ok(updatedTask);
    }

    [HttpGet("{taskId}")]
    public async Task<IActionResult> GetDailyTaskDetail(Guid taskId)
    {
        var taskDetail = await _dailyTaskService.GetDailyTaskAsync(taskId);
        return Ok(taskDetail);
    }

    [HttpGet]
    public async Task<IActionResult> GetDailyTaskListByUser([FromQuery] Guid userId)
    {
        var taskList = await _dailyTaskService.GetDailyTasksByUserIdAsync(userId);
        return Ok(taskList);
    }
}
