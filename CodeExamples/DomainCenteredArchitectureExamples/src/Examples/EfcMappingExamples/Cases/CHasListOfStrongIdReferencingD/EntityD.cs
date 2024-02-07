namespace EfcMappingExamples.Cases.CHasListOfStrongIdReferencingD;

public class EntityD
{
    public StrongIdForEntityD Id { get; }

    private string someValue = "42";

    public EntityD(StrongIdForEntityD id) => Id = id;
    
    private EntityD(){}
}