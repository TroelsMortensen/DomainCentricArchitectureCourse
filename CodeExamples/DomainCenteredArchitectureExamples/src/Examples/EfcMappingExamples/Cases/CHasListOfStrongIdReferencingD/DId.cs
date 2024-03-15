namespace EfcMappingExamples.Cases.CHasListOfStrongIdReferencingD;

public class DId
{
    public Guid Value { get; }

    public static DId Create() => new(Guid.NewGuid());

    public static DId FromGuid(Guid id) => new(id);

    private DId(Guid newGuid)
        => Value = newGuid;
}