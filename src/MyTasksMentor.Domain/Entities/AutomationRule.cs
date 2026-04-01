namespace MyTasksMentor.Domain.Entities;

public class AutomationRule
{
    public Guid Id { get; private set; }

    public Guid UserId { get; private set; }

    public string Name { get; private set; } = string.Empty;

    public string Trigger { get; private set; } = string.Empty;

    public string Action { get; private set; } = string.Empty;

    public bool IsActive { get; private set; }

    public DateTime CreatedAt { get; private set; }

    // Constructor
    public AutomationRule(Guid userId, string name, string trigger, string action)
    {
        if (userId == Guid.Empty)
            throw new ArgumentException("UserId is required.");

        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name cannot be empty.");

        if (string.IsNullOrWhiteSpace(trigger))
            throw new ArgumentException("Trigger cannot be empty.");

        if (string.IsNullOrWhiteSpace(action))
            throw new ArgumentException("Action cannot be empty.");

        Id = Guid.NewGuid();
        UserId = userId;
        Name = name;
        Trigger = trigger;
        Action = action;
        IsActive = true;
        CreatedAt = DateTime.UtcNow;
    }

    // Métodos de negocio
    public void Activate()
    {
        IsActive = true;
    }

    public void Deactivate()
    {
        IsActive = false;
    }
}