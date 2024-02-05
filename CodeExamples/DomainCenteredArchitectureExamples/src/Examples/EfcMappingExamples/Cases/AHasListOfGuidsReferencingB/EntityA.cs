namespace EfcMappingExamples.Cases.AHasListOfGuidsReferencingB;

public class EntityA
{
    public Guid Id { get; }

    private string someValue = "42";

    internal List<Guid> foreignKeysToB;

    public EntityA(Guid id)
    {
        Id = id;
        foreignKeysToB = new();
    }

    private EntityA()
    {
        
    }
    
    public void AddFks(params Guid[] fks) => foreignKeysToB.AddRange(fks);
}