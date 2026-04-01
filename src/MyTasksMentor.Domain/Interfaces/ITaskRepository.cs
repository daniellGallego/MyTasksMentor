using MyTasksMentor.Domain.Entities;

namespace MyTasksMentor.Domain.Interfaces
{
    public interface ITaskRepository
    {
        Task<TaskItem?> GetByIdAsync(Guid id);

        Task<List<TaskItem>> GetByUserIdAsync(Guid userId);

        Task AddAsync(TaskItem task);

        Task UpdateAsync(TaskItem task);

        Task DeleteAsync(Guid id);
    }
}
