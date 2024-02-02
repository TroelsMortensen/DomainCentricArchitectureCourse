namespace EfcMappingExamples.Aggregates.ThirdAggregate;

public class OtherEntity
{
    public Guid Id { get; }

    public OtherEntity(Guid id)
    {
        Id = id;
    }

    private OtherEntity() // for efc
    {
        
    }
}