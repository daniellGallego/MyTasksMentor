using MongoDB.Driver;
using MyTasksMentor.Domain.Entities;
using MyTasksMentor.Domain.Interfaces;
using MyTasksMentor.Infrastructure.Persistence;

namespace MyTasksMentor.Infrastructure.Repositories;

public class NoteRepository : INoteRepository
{
    private readonly IMongoCollection<Note> _collection;

    public NoteRepository(MongoDbContext context)
    {
        _collection = context.GetCollection<Note>("Notes");
    }

    public async Task AddAsync(Note note)
    {
        await _collection.InsertOneAsync(note);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _collection.DeleteOneAsync(n => n.Id == id);
    }

    public async Task<List<Note>> GetByUserIdAsync(Guid userId)
    {
        return await _collection.Find(n => n.UserId == userId).ToListAsync();
    }

    public async Task UpdateAsync(Note note)
    {
        await _collection.ReplaceOneAsync(n => n.Id == note.Id, note);
    }
}