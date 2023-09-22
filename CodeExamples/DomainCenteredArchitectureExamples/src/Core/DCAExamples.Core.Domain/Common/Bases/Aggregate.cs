namespace DCAExamples.Core.Domain.Common.Bases;

public abstract class Aggregate
{
    public Guid Id { get;  }

    protected Aggregate(Guid id)
    {
        Id = id;
    }
}