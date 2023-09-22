using DCAExamples.Core.Domain.Common.OperationResult;

namespace DCAExamples.Core.Domain.Aggregates.ProjectTaskAggregate.Values;

public class TaskId
{
    public static Result<TaskId> Create(Guid id)
    {
        throw new NotImplementedException();
    }

    public Guid Value { get; set; }
}