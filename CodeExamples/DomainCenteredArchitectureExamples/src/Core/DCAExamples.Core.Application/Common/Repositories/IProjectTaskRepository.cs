using DCAExamples.Core.Domain.Aggregates.ProjectTaskAggregate.Entities;
using DCAExamples.Core.Domain.Aggregates.ProjectTaskAggregate.Values;

namespace DCAExamples.Core.Application.Common.Repositories;

public interface IProjectTaskRepository
{
    Task<ProjectTask> FindAsync(TaskId commandTaskId);

}