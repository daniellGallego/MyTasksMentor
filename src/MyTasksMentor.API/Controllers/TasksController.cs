using Microsoft.AspNetCore.Mvc;
using MyTasksMentor.Application.DTOs;
using MyTasksMentor.Application.Services;

namespace MyTasksMentor.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TasksController : ControllerBase
{
    private readonly TaskService _taskService;

    public TasksController(TaskService taskService)
    {
        _taskService = taskService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateTask([FromBody] CreateTaskRequest request)
    {
        var result = await _taskService.CreateTaskAsync(request);

        return Ok(result);
    }

    [HttpGet("user/{userId}")]
    public async Task<IActionResult> GetTasksByUser(Guid userId)
    {
        var result = await _taskService.GetTasksByUserIdAsync(userId);

        return Ok(result);
    }

    [HttpPatch("{id}/complete")]
    public async Task<IActionResult> CompleteTask(Guid id)
    {
        await _taskService.CompleteTaskAsync(id);

        return NoContent();
    }

    [HttpGet("summary/{userId}")]
    public async Task<IActionResult> GetSummary(Guid userId)
    {
        var result = await _taskService.GetTasksSummaryAsync(userId);

        return Ok(new { summary = result });
    }

    [HttpGet("notes-analysis/{userId}")]
    public async Task<IActionResult> AnalyzeNotes(Guid userId)
    {
        var result = await _taskService.AnalyzeUserNotesAsync(userId);

        return Ok(new { analysis = result });
    }
}