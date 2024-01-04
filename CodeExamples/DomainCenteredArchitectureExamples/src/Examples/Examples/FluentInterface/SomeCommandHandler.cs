using DCAExamples.Core.Domain.Common.OperationResult;

namespace Examples.FluentInterface;

public class SomeCommandHandler : 
    ICommandHandler<string>.WithResult
{
    public Task<Result> HandleAsync(string command)
    {
        return Task.FromResult(new Result());
    }
}

public class SomeOtherCommandHandler : 
    ICommandHandler<string>.WithoutResult
{
    public Task HandleAsync(string command)
    {
        return Task.CompletedTask;
    }
}