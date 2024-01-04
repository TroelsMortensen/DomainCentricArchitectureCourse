using DCAExamples.Core.Domain.Aggregates.ProjectTaskAggregate.Values;
using DCAExamples.Core.Domain.Common.Bases;
using DCAExamples.Core.Domain.Common.Exceptions;
using DCAExamples.Core.Domain.Common.OperationResult;

namespace DCAExamples.Core.Domain.Aggregates.ProjectTaskAggregate.Entities;

public class ProjectTask : AggregateRoot
{
    private TaskId id;
    private TaskDescription description;
    private bool isCompleted;
    private TeamMemberName assignee;
    private List<ProjectTask> subTasks = new List<ProjectTask>();

    public bool IsCompleted => isCompleted;
    public Estimate Estimate { get; set; }

    public void Complete()
    {
        if (subTasks.Any(task => !task.IsCompleted))
        {
            throw new Exception("Cannot complete Todo item before all sub-tasks are completed");
        }

        isCompleted = true;
    }

    public void AssignTo(TeamMemberName userName)
    {
        if (assignee != null)
        {
            throw new Exception("Todo already assigned");
        }

        assignee = userName;
    }

    public void UpdateDescription(TaskDescription desc)
    {
        if (desc == null)
            throw new InvalidArgumentException("Task description cannot be empty");
        description = desc;
    }

    public Result UpdateRemainingEstimate(Estimate remainingEstimate)
    {
        throw new NotImplementedException();
    }

    public static ProjectTask Create(TaskId taskId, Estimate estimateValue)
    {
        throw new NotImplementedException();
    }
}