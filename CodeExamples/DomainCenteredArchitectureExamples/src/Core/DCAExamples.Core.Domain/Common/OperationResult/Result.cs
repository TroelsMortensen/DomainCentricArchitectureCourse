namespace DCAExamples.Core.Domain.Common.OperationResult;

public class Result<T>
{
    public T Value { get; set; }

    public string ErrorMessage { get; private set; } = null!;
    
    public Result(T value) => Value = value;
    public Result(string error) => ErrorMessage = error;

    public Result(List<string> errors)
    {

    }

    

    public bool IsSuccess => string.IsNullOrEmpty(ErrorMessage);
    public List<string> ErrorMessages { get; set; }
    public bool IsFailure => !IsSuccess;

    public static Result<T> FromResult<T2>(Result<T2> result)
    {
        return new Result<T>(result.ErrorMessages);
    }

    public Result<T> WithResult<T2>(Result<T2> result)
    {
        result.ErrorMessages.AddRange(result.ErrorMessages);
        return this;
    }
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