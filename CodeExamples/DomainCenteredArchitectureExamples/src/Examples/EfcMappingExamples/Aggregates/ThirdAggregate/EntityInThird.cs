namespace EfcMappingExamples.Aggregates.ThirdAggregate;

public class EntityInThird
{
    public Guid Id { get; }

    internal string someString = "Hello there";

    public EntityInThird(Guid id)
    {
        Id = id;
    }

    private EntityInThird() // for efc
    {
        
    }
}