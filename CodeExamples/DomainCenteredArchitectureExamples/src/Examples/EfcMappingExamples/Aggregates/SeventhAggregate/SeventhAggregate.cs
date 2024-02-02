using EfcMappingExamples.Aggregates.ThirdAggregate;

namespace EfcMappingExamples.Aggregates.SeventhAggregate;

public class SeventhAggregate
{
    public Guid Id { get; }

    internal List<EntityInThird> nestedEntities;
    
    public SeventhAggregate(Guid id)
    {
        Id = id;
        nestedEntities = new();
    }

    private SeventhAggregate()
    {
        
    }

    public void AddEntity(EntityInThird ent) => nestedEntities.Add(ent);
}