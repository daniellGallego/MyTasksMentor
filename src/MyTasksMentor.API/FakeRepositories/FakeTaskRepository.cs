using MyTasksMentor.Domain.Entities;
using MyTasksMentor.Domain.Interfaces;

namespace MyTasksMentor.API.FakeRepositories;

public class FakeTaskRepository : ITaskRepository
{
    private readonly List<TaskItem> _tasks = new();

    public Task AddAsync(TaskItem task)
    {
        _tasks.Add(task);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(Guid id)
    {
        _tasks.RemoveAll(t => t.Id == id);
        return Task.CompletedTask;
    }

    public Task<TaskItem?> GetByIdAsync(Guid id)
    {
        var task = _tasks.FirstOrDefault(t => t.Id == id);
        return Task.FromResult(task);
    }

    public Task<List<TaskItem>> GetByUserIdAsync(Guid userId)
    {
        var result = _tasks.Where(t => t.UserId == userId).ToList();
        return Task.FromResult(result);
    }

    public Task UpdateAsync(TaskItem task)
    {
        return Task.CompletedTask;
    }
}