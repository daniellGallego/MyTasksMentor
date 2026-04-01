namespace MyTasksMentor.Domain.Entities;

public class Note
{
    public Guid Id { get; private set; }

    public Guid UserId { get; private set; }

    public string Title { get; private set; } = string.Empty;

    public string Content { get; private set; } = string.Empty;

    public DateTime CreatedAt { get; private set; }

    public DateTime? UpdatedAt { get; private set; }

    // Constructor
    public Note(Guid userId, string title, string content)
    {
        if (userId == Guid.Empty)
            throw new ArgumentException("UserId is required.");

        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Title cannot be empty.");

        if (string.IsNullOrWhiteSpace(content))
            throw new ArgumentException("Content cannot be empty.");

        Id = Guid.NewGuid();
        UserId = userId;
        Title = title;
        Content = content;
        CreatedAt = DateTime.UtcNow;
    }

    // Métodos de negocio
    public void Update(string title, string content)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Title cannot be empty.");

        if (string.IsNullOrWhiteSpace(content))
            throw new ArgumentException("Content cannot be empty.");

        Title = title;
        Content = content;
        UpdatedAt = DateTime.UtcNow;
    }
}

