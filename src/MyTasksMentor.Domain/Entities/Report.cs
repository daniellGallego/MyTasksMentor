namespace MyTasksMentor.Domain.Entities;

public class Report
{
    public Guid Id { get; private set; }

    public Guid UserId { get; private set; }

    public string Title { get; private set; } = string.Empty;

    public string Content { get; private set; } = string.Empty;

    public DateTime CreatedAt { get; private set; }

    // Constructor
    public Report(Guid userId, string title, string content)
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

    // Método de negocio
    public void UpdateContent(string content)
    {
        if (string.IsNullOrWhiteSpace(content))
            throw new ArgumentException("Content cannot be empty.");

        Content = content;
    }
}