namespace MyTasksMentor.Domain.Entities;

public class TaskItem
{
    public Guid Id { get; private set; }
    public Guid UserId { get; private set; }

    public string Title { get; private set; } = string.Empty;

    public string? Description { get; private set; }

    public bool IsCompleted { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public DateTime? DueDate { get; private set; }

    // Constructor principal
    public TaskItem(Guid userId, string title, string? description, DateTime? dueDate)
    {
        if (userId == Guid.Empty)
            throw new ArgumentException("UserId is required.");

        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Title cannot be empty.");

        if (title.Length > 200)
            throw new ArgumentException("Title cannot exceed 200 characters.");

        Id = Guid.NewGuid();
        UserId = userId;
        Title = title;
        Description = description;
        DueDate = dueDate;
        CreatedAt = DateTime.UtcNow;
        IsCompleted = false;
    }

    // Método de negocio
    public void MarkAsCompleted()
    {
        IsCompleted = true;
    }

    public void UpdateDetails(string title, string? description, DateTime? dueDate)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Title cannot be empty.");

        if (title.Length > 200)
            throw new ArgumentException("Title cannot exceed 200 characters.");

        Title = title;
        Description = description;
        DueDate = dueDate;
    }
}