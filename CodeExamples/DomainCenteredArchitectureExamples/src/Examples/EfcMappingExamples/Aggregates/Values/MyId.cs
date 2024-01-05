namespace EfcMappingExamples.Aggregates.Values;

public class MyId
{
    public Guid Get { get; }

    public static MyId Create()
    {
        return new MyId();
    }
    
    private MyId()
    {
        Get = Guid.NewGuid();
    }

    public static MyId FromGuid(Guid guid)
    {
        return new MyId(guid);
    }

    private MyId(Guid id)
    {
        Get = id;
    }

    protected bool Equals(MyId other)
    {
        return Get.Equals(other.Get);
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((MyId)obj);
    }

    public override int GetHashCode()
    {
        return Get.GetHashCode();
    }
}