namespace EfcMappingExamples.Cases.CHasListOfStrongIdReferencingD;

public class EntityD
{
    public DId Id { get; }

    public EntityD(DId id) => Id = id;
    
    private EntityD(){}
}