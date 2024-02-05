namespace EfcMappingExamples.Cases.AHasListOfGuidsReferencingB;

public class EntityB
{
    public Guid Id { get; }

    private string someOtherValue = "47";
    
    public EntityB(Guid id)
    {
        Id = id;
    }

    private EntityB()
    {
        
    }
}