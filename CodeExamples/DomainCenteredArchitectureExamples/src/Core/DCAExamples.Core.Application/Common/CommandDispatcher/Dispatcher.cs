using DCAExamples.Core.Application.Common.CommandHandler;
using DCAExamples.Core.Domain.Common.OperationResult;

namespace DCAExamples.Core.Application.Common.CommandDispatcher;

public class Dispatcher : ICommandDispatcher
{
    private readonly IServiceProvider serviceProvider;

    public Dispatcher(IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider;
    }

    public Task<Result> DispatchAsync<TCommand>(TCommand command) 
    {
        Type handlerInterfaceType = typeof(ICommandHandler<>);

        Type handlerInterfaceWithCommandType = handlerInterfaceType.MakeGenericType(command.GetType());

        ICommandHandler<TCommand> commandHandler =
            (ICommandHandler<TCommand>) serviceProvider.GetService(handlerInterfaceWithCommandType)!;

        return commandHandler.HandleAsync(command);      
    }
}