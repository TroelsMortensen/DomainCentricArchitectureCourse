namespace EfcMappingExamples.Cases.CHasListOfStrongIdReferencingD;

public class StrongIdForEntityD
{
    public Guid Value { get; }

    public static StrongIdForEntityD Create() => new(Guid.NewGuid());

    public static StrongIdForEntityD FromGuid(Guid id) => new(id);

    private StrongIdForEntityD(Guid newGuid)
        => Value = newGuid;

    private StrongIdForEntityD() // for efc
    {
    }
}