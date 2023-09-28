using DCAExamples.Core.Domain.Common.Values;

namespace DCAExamples.Core.Domain.Common.Bases;

public abstract class AggregateRoot<TId> : Entity<TId>
{
    protected AggregateRoot(TId id) : base(id)
    {
    }
    
    protected AggregateRoot() { }

}