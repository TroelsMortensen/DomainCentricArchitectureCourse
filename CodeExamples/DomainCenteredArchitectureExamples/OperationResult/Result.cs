namespace OperationResult;

public class Result<T>
{
    public T Value { get; private set; }

    public string ErrorMessage { get; private set; } = null!;
    
    public Result(T value) => Value = value;
    public Result(string error) => ErrorMessage = error;
    public bool IsSuccess => string.IsNullOrEmpty(ErrorMessage);
    

}

public class Result
{

    public string ErrorMessage { get; private set; } = null!;
    public Result() {}
    public Result(string error) => ErrorMessage = error;
    public bool IsSuccess => string.IsNullOrEmpty(ErrorMessage);
    public bool HasErrors => !IsSuccess;

    public static Result<TV> Failure<TV>(string error)
    {
        return new Result<TV>(error);
    }

    public static Result Failure(string enumerable)
    {
        throw new NotImplementedException();
    }
    
    public static Result<TV> Success<TV>(TV value)
    {
        return new Result<TV>(value);
    }

    public static Result Success()
    {
        throw new NotImplementedException();
    }
}