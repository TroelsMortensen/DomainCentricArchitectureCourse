using DCAExamples.Core.Domain.Common.OperationResult;

namespace DCAExamples.Core.Application.Common.CommandHandler;

public interface ICommandHandler<TCommand> 
{
    Task<Result> HandleAsync(TCommand command);
}