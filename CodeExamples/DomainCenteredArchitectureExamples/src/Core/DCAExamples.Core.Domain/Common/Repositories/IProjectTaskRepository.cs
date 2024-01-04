using DCAExamples.Core.Domain.Aggregates.ProjectTaskAggregate.Entities;
using DCAExamples.Core.Domain.Aggregates.ProjectTaskAggregate.Values;

namespace DCAExamples.Core.Domain.Common.Repositories;

public interface IProjectTaskRepository
    : IGenericRepository<ProjectTask>
{
}