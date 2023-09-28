using DCAExamples.Core.Domain.Common.Bases;

namespace DCAExamples.Core.Domain.Aggregates.ProjectTaskAggregate.Entities;

public class SubTask : Entity<SubTaskId>
{
    public SubTask(SubTaskId id) : base(id)
    {
        
    }


    // ... the rest
}

public class SubTaskId {
    public Guid Id { get; }

    public SubTaskId(Guid id) { Id = id; }
}