namespace DCAExamples.Core.Domain.Common.Bases;

public abstract class Entity
{
    public Guid Id { get;  }

    protected Entity(Guid id)
    {
        Id = id;
    }

    protected Entity() { }
    
    public override bool Equals(object? obj)
    {
        if (obj is null || obj.GetType() != GetType())
        {
            return false;
        }

        return ((Entity)obj).Id == Id;
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}