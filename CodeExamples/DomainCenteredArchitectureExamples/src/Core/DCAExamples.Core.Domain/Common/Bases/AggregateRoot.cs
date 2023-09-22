namespace DCAExamples.Core.Domain.Common.Bases;

public abstract class AggregateRoot : Entity
{
    protected AggregateRoot(Guid id) : base(id)
    {
    }
    
    protected AggregateRoot() { }

}