using MyTasksMentor.Application.DTOs;
using MyTasksMentor.Domain.Entities;
using MyTasksMentor.Domain.Interfaces;
using MyTasksMentor.Domain.Exceptions;
using MyTasksMentor.Application.DTOs;

namespace MyTasksMentor.Application.Services;

public class TaskService
{
    private readonly ITaskRepository _taskRepository;
    private readonly AiService _aiService;
    private readonly INoteRepository _noteRepository;
    public TaskService(ITaskRepository taskRepository, 
        AiService aiService,
        INoteRepository noteRepository)

    {
        _taskRepository = taskRepository;
        _aiService = aiService;
        _noteRepository = noteRepository;
    }

    public async Task<TaskResponse> CreateTaskAsync(CreateTaskRequest request)
    {
        var task = new TaskItem(
            request.UserId,
            request.Title,
            request.Description,
            request.DueDate
        );

        await _taskRepository.AddAsync(task);

        return new TaskResponse
        {
            Id = task.Id,
            Title = task.Title,
            Description = task.Description,
            IsCompleted = task.IsCompleted,
            CreatedAt = task.CreatedAt,
            DueDate = task.DueDate
        };
    }
    public async Task<List<TaskResponse>> GetTasksByUserIdAsync(Guid userId)
    {
        var tasks = await _taskRepository.GetByUserIdAsync(userId);

        return tasks.Select(task => new TaskResponse
        {
            Id = task.Id,
            Title = task.Title,
            Description = task.Description,
            IsCompleted = task.IsCompleted,
            CreatedAt = task.CreatedAt,
            DueDate = task.DueDate
        }).ToList();
    }
    public async Task CompleteTaskAsync(Guid taskId)
    {
        var task = await _taskRepository.GetByIdAsync(taskId);

        if (task is null)
            throw new DomainException("Task not found");

        task.MarkAsCompleted();

        await _taskRepository.UpdateAsync(task);
    }
    public async Task<string> GetTasksSummaryAsync(Guid userId)
    {
        var tasks = await _taskRepository.GetByUserIdAsync(userId);

        var pendingTasks = tasks.Where(t => !t.IsCompleted).ToList();

        var taskDescriptions = pendingTasks
            .Select(t => $"{t.Title} - {t.Description}")
            .ToList();


        return await _aiService.GenerateSummaryAsync(taskDescriptions);
    }

    public async Task<string> AnalyzeUserNotesAsync(Guid userId)
    {
        var notes = await _noteRepository.GetByUserIdAsync(userId);

        var content = notes.Select(n => $"{n.Title}: {n.Content}").ToList();

        return await _aiService.AnalyzeNotesAsync(content);
    }
    public async Task CreateNoteAsync(CreateNoteRequest request)
    {
        var note = new Note(
            request.UserId,
            request.Title,
            request.Content
        );

        await _noteRepository.AddAsync(note);
    }
}