using MongoDB.Driver;
using MyTasksMentor.Domain.Entities;
using MyTasksMentor.Domain.Interfaces;
using MyTasksMentor.Infrastructure.Persistence;

namespace MyTasksMentor.Infrastructure.Repositories;

public class TaskRepository : ITaskRepository
{
    private readonly IMongoCollection<TaskItem> _collection;

    public TaskRepository(MongoDbContext context)
    {
        _collection = context.GetCollection<TaskItem>("Tasks");
    }

    public async Task AddAsync(TaskItem task)
    {
        await _collection.InsertOneAsync(task);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _collection.DeleteOneAsync(t => t.Id == id);
    }

    public async Task<TaskItem?> GetByIdAsync(Guid id)
    {
        return await _collection.Find(t => t.Id == id).FirstOrDefaultAsync();
    }

    public async Task<List<TaskItem>> GetByUserIdAsync(Guid userId)
    {
        return await _collection.Find(t => t.UserId == userId).ToListAsync();
    }

    public async Task UpdateAsync(TaskItem task)
    {
        await _collection.ReplaceOneAsync(t => t.Id == task.Id, task);
    }
}