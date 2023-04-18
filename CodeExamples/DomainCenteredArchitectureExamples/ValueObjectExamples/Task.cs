namespace ValueObjectExamples;

public class Task
{
    private string title;
    private string description;
    private string assigneeName;
    private string deadline;

    public Task(string title, string description, string assigneeName, string deadline)
    {
        this.title = title;
        this.description = description;
        this.assigneeName = assigneeName;
        this.deadline = deadline;
    }
}