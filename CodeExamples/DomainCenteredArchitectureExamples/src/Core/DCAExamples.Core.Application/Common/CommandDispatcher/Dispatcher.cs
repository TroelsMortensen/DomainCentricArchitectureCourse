using DCAExamples.Core.Application.Common.CommandHandler;
using DCAExamples.Core.Domain.Common.OperationResult;
using Microsoft.Extensions.DependencyInjection;

namespace DCAExamples.Core.Application.Common.CommandDispatcher;

public class Dispatcher : ICommandDispatcher
{
    private readonly IServiceProvider serviceProvider;

    public Dispatcher(IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider;
    }


    // I can use GetRequiredService because extension method, see using above
    public Task<Result> DispatchAsync<TCommand>(TCommand command)
    {
        ICommandHandler<TCommand> service = serviceProvider
                            .GetRequiredService<ICommandHandler<TCommand>>();

        return service.HandleAsync(command);
    }
}