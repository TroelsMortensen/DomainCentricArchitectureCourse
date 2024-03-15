namespace EfcMappingExamples.Cases.CHasListOfStrongIdReferencingD;

public class EntityC
{
    public Guid Id { get; }

    internal List<ReferenceFromCtoD> foreignKeysToD;

    public EntityC(Guid id)
    {
        Id = id;
        foreignKeysToD = new();
    }

    public void AddFk(DId id) => foreignKeysToD.Add(id);
}

public class ReferenceFromCtoD
{
    public DId FkToD { get; set; }

    public static implicit operator ReferenceFromCtoD(DId fk) => new(fk);

    public static implicit operator DId(ReferenceFromCtoD reference) => reference.FkToD;

    private ReferenceFromCtoD(DId fk) => FkToD = fk;
    private ReferenceFromCtoD(){}
}