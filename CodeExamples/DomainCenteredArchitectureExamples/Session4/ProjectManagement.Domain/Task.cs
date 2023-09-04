namespace ProjectManagement.Domain;

public class Task
{
    public TaskId Id { get; private set; }
    internal TaskDescription Description { get; private set; }
    internal Estimate Estimate { get; private set; }
    
    // ...
}

internal record Estimate(int Value)
{
}

internal record TaskDescription(string Value)
{
}

public record TaskId(Guid Value)
{
}