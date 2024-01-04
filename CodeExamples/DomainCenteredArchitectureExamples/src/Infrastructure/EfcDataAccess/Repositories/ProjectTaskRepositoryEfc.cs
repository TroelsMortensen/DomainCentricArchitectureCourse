using DCAExamples.Core.Domain.Aggregates.ProjectTaskAggregate.Entities;
using DCAExamples.Core.Domain.Common.Repositories;
using EfcDataAccess.Context;

namespace EfcDataAccess.Repositories;

public class ProjectTaskRepositoryEfc :
    RepositoryBase<ProjectTask>, IProjectTaskRepository
{
    public ProjectTaskRepositoryEfc(ProjectDbContext context)
        : base(context)
    {
    }

    public override Task<ProjectTask> GetAsync(Guid id)
    {
        // load the aggregate, include all dependent entities.
        return null;
    }
}