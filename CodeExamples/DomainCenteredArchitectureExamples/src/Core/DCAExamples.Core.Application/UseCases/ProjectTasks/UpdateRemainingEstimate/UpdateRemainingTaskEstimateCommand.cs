using DCAExamples.Core.Domain.Aggregates.ProjectTaskAggregate.Values;
using DCAExamples.Core.Domain.Common.OperationResult;

namespace DCAExamples.Core.Application.UseCases.ProjectTasks.UpdateRemainingEstimate;

public class UpdateRemainingTaskEstimateCommand 
{
    public TaskId TaskId { get; private set; }
    public Estimate RemainingEstimate { get; private set; }

    public static Result<UpdateRemainingTaskEstimateCommand> Create(Guid id, int estimate)
    {
        Result<TaskId> taskIdResult = TaskId.Create(id);
        Result<Estimate> estimateResult = Estimate.Create(estimate);
        List<string> errors = new List<string>();
        UpdateRemainingTaskEstimateCommand command = new UpdateRemainingTaskEstimateCommand(taskIdResult.Value, estimateResult.Value);
        Result<UpdateRemainingTaskEstimateCommand> result = Result<UpdateRemainingTaskEstimateCommand>
            .FromResult(taskIdResult)
            .WithResult(estimateResult);
        if (result.IsSuccess)
        {
            result.Value = command;
        }

        return result;
    }

    private UpdateRemainingTaskEstimateCommand(TaskId taskTaskId, Estimate remainingEstimate)
    {
        TaskId = taskTaskId;
        RemainingEstimate = remainingEstimate;
    }
}