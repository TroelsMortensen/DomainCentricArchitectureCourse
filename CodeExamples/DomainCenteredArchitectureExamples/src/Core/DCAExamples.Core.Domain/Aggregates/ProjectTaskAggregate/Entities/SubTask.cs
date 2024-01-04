using DCAExamples.Core.Domain.Common.Bases;

namespace DCAExamples.Core.Domain.Aggregates.ProjectTaskAggregate.Entities;

public class SubTask : Entity
{
    public SubTask(Guid id) : base(id)
    {
        
    }


    // ... the rest
}

public class SubTaskId {
    public Guid Id { get; }

    public SubTaskId(Guid id) { Id = id; }
}