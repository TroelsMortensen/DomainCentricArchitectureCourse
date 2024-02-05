namespace EfcMappingExamples.Cases.AHasListOfGuidsReferencingB;

public class EntityBFk(Guid FkToB)
{
    public Guid FkToB { get; private set; } = FkToB;
}
