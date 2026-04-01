using MyTasksMentor.Domain.Entities;

namespace MyTasksMentor.Domain.Interfaces
{
    public interface INoteRepository
    {
        Task<List<Note>> GetByUserIdAsync(Guid userId);

        Task AddAsync(Note note);

        Task UpdateAsync(Note note);

        Task DeleteAsync(Guid id);
    }
}
