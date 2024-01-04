using System.Diagnostics;
using DCAExamples.Core.Domain.Common.OperationResult;

namespace DCAExamples.Core.Application.Common.CommandDispatcher;

public class CommandExecutionTimer : ICommandDispatcher
{
    private readonly ICommandDispatcher next;

    public CommandExecutionTimer(ICommandDispatcher next) => this.next = next;

    public async Task<Result> DispatchAsync<TCommand>(TCommand command)
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        Result result = await next.DispatchAsync(command);

        TimeSpan elapsedTime = stopwatch.Elapsed;
        // do something with the time, log it, store in DB, whatever
        
        return result;
    }
}