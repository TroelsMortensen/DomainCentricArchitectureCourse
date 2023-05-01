namespace OperationResult;

public class Todo
{

    public static Result<Todo> Create(TodoId id, TodoDescription description)
    {
        Result validation = Validate(id, description);
        
        if (validation.HasErrors) return Result.Failure<Todo>(validation.ErrorMessage);
       
        // ...
        Todo todo = new Todo(id, description);
        return Result.Success(todo);
    }

    private Todo(TodoId id, TodoDescription description)
    {
        //...
    }

    
    private static Result Validate(TodoId id, TodoDescription description)
    {
        if (id is null) return new("Must have id");
        if (description is null) return new("Must provide description");
        // more validation if needed?
        return new();
    }


    public Result<SubTask> GetSubTask(int id)
    {
        SubTask? sub = subTasks
            .FirstOrDefault(subTask => subTask.Id == id);
        if (sub is null)
        {
            return new Result<SubTask>("Subtask not found");
        }

        return new (sub);
    }
    // ...
    
    private int id;
    private string description;
    private bool isCompleted;
    private string? assignee;


    private List<SubTask> subTasks = new List<SubTask>();

    public void Complete()
    {
        if (subTasks.Any(task => !task.IsCompleted))
        {
            throw new Exception("Cannot complete Todo item before all sub-tasks are completed");
        }

        isCompleted = true;
    }

    public void AssignTo(string userName)
    {
        if (!string.IsNullOrEmpty(assignee))
        {
            throw new Exception("Todo already assigned");
        }

        assignee = userName;
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

        description = desc;
    }

    private TodoRepository todoRepository;



    public Result<SubTask> UpdateSubTaskWithX(int todoId, int subTaskId)
    {
        Todo todo = todoRepository.Get(todoId);
        Result<SubTask> result = todo.GetSubTask(subTaskId);
        if (!result.IsSuccess)
        {
            return result;
        }

        SubTask st = result.Value;
        // do something with subtask
        return new Result<SubTask>(st);
    }
    
    public Result UpdateSubTaskWithY(int todoId, int subTaskId)
    {
        Todo todo = todoRepository.Get(todoId);
        Result<SubTask> result = todo.GetSubTask(subTaskId);
        if (!result.IsSuccess)
        {
            return new (result.ErrorMessage);
        }

        SubTask st = result.Value;
        // do something with subtask
        return new ();
    }


    private void Example()
    {
       
    }
}

public class TodoDescription
{
}

public class TodoId
{
}

public class TodoRepository
{
    public Todo Get(int todoId)
    {
        throw new NotImplementedException();
    }
}
public class SubTask
{
    public int Id { get; private set; }
    public string Description { get; private set; }
    public bool IsCompleted { get; private set; }
}

