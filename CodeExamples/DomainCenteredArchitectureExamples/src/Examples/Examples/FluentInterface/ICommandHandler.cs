using DCAExamples.Core.Domain.Common.OperationResult;

namespace Examples.FluentInterface;

public interface ICommandHandler<T>
{
    public interface WithoutResult
    {
        Task HandleAsync(T command);
    }

    public interface WithResult
    {
        Task<Result> HandleAsync(T command);
    }
}