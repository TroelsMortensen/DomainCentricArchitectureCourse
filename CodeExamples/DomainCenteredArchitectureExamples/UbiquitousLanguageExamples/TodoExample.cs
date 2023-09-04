namespace UbiquitousLanguageExamples;

public class Todo
{
    public int Id { get; set; }
    public string Description { get; set; }
    public bool IsCompleted { get; set; }
    public string? Assignee { get; set; }
}

public class DddTodo
{
    public int Id { get; internal set; }
    private string Description { get; set; }
    private bool IsCompleted { get; set; }
    private string? Assignee { get; set; }
    private List<SubTask> SubTasks { get; set; } = new List<SubTask>();

    public void Complete()
    {
        if (SubTasks.Any(task => !task.IsCompleted))
        {
            throw new Exception("Cannot complete Todo item before all sub-tasks are completed");
        }

        IsCompleted = true;
    }

    public void AssignTo(string userName)
    {
        if (!string.IsNullOrEmpty(Assignee))
        {
            throw new Exception("Todo already assigned");
        }

        Assignee = userName;
    }

    public void UpdateDescription(string desc)
    {
        if (string.IsNullOrEmpty(desc))
        {
            throw new Exception("Description cannot be empty");
        }

        if (desc.Length > 150)
        {
            throw new Exception("Description must be less than 150 characters");
        }

        Description = desc;
    }
}

public class SubTask
{
    public int Id { get; private set; }
    public string Description { get; private set; }
    public bool IsCompleted { get; private set; }
}

public class Usage
{
    private ITodoRepository todoRepository;

    public void AssignTodoToUser(int todoId, string username)
    {
        Todo todo = todoRepository.GetById(todoId);
        if (!string.IsNullOrEmpty(todo.Assignee))
        {
            throw new Exception("Todo already assigned");
        }

        todo.Assignee = username;

        todoRepository.Save(todo);
    }

    public void DddAssignTodoToUser(int todoId, string username)
    {
        DddTodo todo = todoRepository.Find(todoId);
        todo.AssignTo(username);

        todoRepository.Save(todo);
    }

    public void Complete(int todoId)
    {
        Todo todo = todoRepository.GetById(todoId);
        todo.IsCompleted = true;

        DddTodo todo2 = todoRepository.Find(todoId);
        todo2.Complete();
    }
}

internal interface ITodoRepository
{
    Todo GetById(int todoId);
    void Save(Todo todo);
    DddTodo Find(int todoId);
    void Save(DddTodo todo);
}