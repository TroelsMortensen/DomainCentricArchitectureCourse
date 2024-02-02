namespace EfcMappingExamples.Aggregates.ThirdAggregate;

public class SomeEntity
{
    public Guid Id { get; }

    internal string someString = "Hello there";

    public SomeEntity(Guid id)
    {
        Id = id;
    }

    private SomeEntity() // for efc
    {
        
    }
}