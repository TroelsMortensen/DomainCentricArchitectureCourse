namespace ValueObjectExamples.DDDTask;

public class Task
{
    private TaskId id;
    private TaskDescription description;
    private bool isCompleted;
    private TeamMemberName assignee;
    private List<Task> subTasks = new List<Task>();

    public bool IsCompleted => isCompleted;

    public void Complete()
    {
        if (subTasks.Any(task => !task.IsCompleted))
        {
            throw new Exception("Cannot complete Todo item before all sub-tasks are completed");
        }

        isCompleted = true;
    }

    public void AssignTo(TeamMemberName userName)
    {
        if (assignee != null)
        {
            throw new Exception("Todo already assigned");
        }

        assignee = userName;
    }

    public void UpdateDescription(TaskDescription desc)
    {
        if (desc == null)
            throw new InvalidArgumentException("Task description cannot be empty");
        description = desc;
    }
}