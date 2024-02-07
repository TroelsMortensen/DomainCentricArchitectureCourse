namespace EfcMappingExamples.Cases.CHasListOfStrongIdReferencingD;

public class EntityC
{
    public Guid Id { get; }

    private string someValue = "42";

    internal List<ReferenceFromCtoD> foreignKeysToD;

    public EntityC(Guid id)
    {
        Id = id;
        foreignKeysToD = new();
    }

    public void AddFk(StrongIdForEntityD id) => foreignKeysToD.Add(new(id));

    private EntityC()
    {
    }
}

public class ReferenceFromCtoD
{
    public StrongIdForEntityD FkToD { get; set; }

    private ReferenceFromCtoD() // EFC
    {
    }

    public ReferenceFromCtoD(StrongIdForEntityD fk)
    {
        FkToD = fk;
    }
}