namespace EfcMappingExamples.Aggregates.Values;

public class MyId
{
    public Guid Get { get; private set; }

    public MyId()
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
}