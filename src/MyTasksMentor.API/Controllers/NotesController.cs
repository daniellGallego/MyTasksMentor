using Microsoft.AspNetCore.Mvc;
using MyTasksMentor.Application.DTOs;
using MyTasksMentor.Application.Services;

namespace MyTasksMentor.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NotesController : ControllerBase
{
    private readonly TaskService _taskService;

    public NotesController(TaskService taskService)
    {
        _taskService = taskService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateNote([FromBody] CreateNoteRequest request)
    {
        await _taskService.CreateNoteAsync(request);

        return Ok();
    }
}