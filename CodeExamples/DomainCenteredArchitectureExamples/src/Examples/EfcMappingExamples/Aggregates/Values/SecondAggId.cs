namespace EfcMappingExamples.Aggregates.Values;

public class SecondAggId
{
    public Guid Get { get; }

    public static SecondAggId Create()
    {
        return new SecondAggId();
    }
    
    private SecondAggId()
    {
        Get = Guid.NewGuid();
    }

    public static SecondAggId FromGuid(Guid guid)
    {
        return new SecondAggId(guid);
    }

    private SecondAggId(Guid id)
    {
        Get = id;
    }

    protected bool Equals(SecondAggId other)
    {
        return Get.Equals(other.Get);
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((SecondAggId)obj);
    }

    public override int GetHashCode()
    {
        return Get.GetHashCode();
    }
}