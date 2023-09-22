using DCAExamples.Core.Domain.Common.OperationResult;

namespace DCAExamples.Core.Application.Common.CommandDispatcher;

public interface ICommandDispatcher
{
    public Task<Result> DispatchAsync<TCommand>(TCommand command);
}