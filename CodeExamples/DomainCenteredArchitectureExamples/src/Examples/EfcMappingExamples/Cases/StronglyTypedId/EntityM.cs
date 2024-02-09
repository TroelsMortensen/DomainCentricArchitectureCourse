namespace EfcMappingExamples.Cases.StronglyTypedId;

public class EntityM
{
    public MId Id { get; }
    public EntityM(MId id) => Id = id;
    private EntityM(){}
}

public class MId
{
    public Guid Value { get; }

    public static MId Create()
        => new MId(Guid.NewGuid());

    public static MId FromGuid(Guid guid)
        => new MId(guid);

    private MId(Guid guid) => Value = guid;

    protected bool Equals(MId other)
    {
        return Value.Equals(other.Value);
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((MId)obj);
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }
}