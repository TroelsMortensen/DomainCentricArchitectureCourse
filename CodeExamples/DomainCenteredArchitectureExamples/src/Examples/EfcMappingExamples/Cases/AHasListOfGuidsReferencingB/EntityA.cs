namespace EfcMappingExamples.Cases.AHasListOfGuidsReferencingB;

public class EntityA
{
    public Guid Id { get; }

    private string someValue = "42";

    internal List<EntityBForeignKey> foreignKeysToB;

    public EntityA(Guid id)
    {
        Id = id;
        foreignKeysToB = new();
    }

    private EntityA()
    {
    }

    public void AddForeignKey(Guid fk) => foreignKeysToB.Add(fk);
}