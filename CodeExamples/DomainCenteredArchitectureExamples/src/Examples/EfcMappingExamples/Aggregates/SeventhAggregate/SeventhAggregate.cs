using EfcMappingExamples.Aggregates.ThirdAggregate;

namespace EfcMappingExamples.Aggregates.SeventhAggregate;

public class SeventhAggregate
{
    public Guid Id { get; }

    internal List<SomeEntity> nestedEntities;
    
    public SeventhAggregate(Guid id)
    {
        Id = id;
        nestedEntities = new();
    }

    private SeventhAggregate()
    {
        
    }

    public void AddEntity(SomeEntity ent) => nestedEntities.Add(ent);
}