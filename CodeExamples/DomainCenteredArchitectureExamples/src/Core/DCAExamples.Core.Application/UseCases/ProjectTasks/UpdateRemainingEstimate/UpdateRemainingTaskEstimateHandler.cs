using DCAExamples.Core.Application.Common.CommandHandler;
using DCAExamples.Core.Domain.Aggregates.ProjectTaskAggregate.Entities;
using DCAExamples.Core.Domain.Common.OperationResult;
using DCAExamples.Core.Domain.Common.Repositories;

namespace DCAExamples.Core.Application.UseCases.ProjectTasks.UpdateRemainingEstimate;

public class UpdateRemainingTaskEstimateHandler : ICommandHandler<UpdateRemainingTaskEstimateCommand>
{
    private readonly IProjectTaskRepository taskRepo;
    private readonly IUnitOfWork uow;

    public UpdateRemainingTaskEstimateHandler(IProjectTaskRepository taskRepo, IUnitOfWork uow)
    {
        this.taskRepo = taskRepo;
        this.uow = uow;
    }

    public async Task<Result> HandleAsync(UpdateRemainingTaskEstimateCommand command)
    {
        ProjectTask task = await taskRepo.FindAsync(command.TaskId);
        Result result = task.UpdateRemainingEstimate(command.RemainingEstimate);
        if (result.HasErrors)
        {
            return result;
        }

        await uow.SaveChangesAsync();
        return Result.Success();
    }
}


// public class ProjectTask
// {
//     public TaskId Id { get; private set; }
//     internal Estimate Estimate { get; private set; }
//     
//     // ...
//     public Result UpdateRemainingEstimate(Estimate commandRemainingEstimate)
//     {
//         throw new NotImplementedException();
//     }
// }