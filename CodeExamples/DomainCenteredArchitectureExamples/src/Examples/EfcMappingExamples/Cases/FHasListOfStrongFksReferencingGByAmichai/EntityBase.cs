namespace EfcMappingExamples.Cases.FHasListOfStrongFksReferencingGByAmichai;

public abstract class EntityBase<TId>
{
    public TId Id { get; protected set; }
}

public abstract class AggregateRootBase<TId, TIdType> : EntityBase<TId>
    where TId : IdBase<TIdType>
{
    public new IdBase<TIdType> Id { get; protected set; }
}

public abstract class IdBase<TId>
{
    public TId Value { get; protected set; } // Abstract?

    protected bool Equals(IdBase<TId> other)
    {
        return EqualityComparer<TId>.Default.Equals(Value, other.Value);
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((IdBase<TId>)obj);
    }

    public override int GetHashCode()
    {
        return EqualityComparer<TId>.Default.GetHashCode(Value);
    }
}