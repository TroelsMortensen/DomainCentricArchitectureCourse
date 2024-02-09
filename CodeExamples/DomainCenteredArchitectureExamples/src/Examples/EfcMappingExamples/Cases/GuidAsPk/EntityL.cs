namespace EfcMappingExamples.Cases.GuidAsPk;

public class EntityL
{
    public Guid Id { get; }

    public EntityL(Guid id)
    {
        Id = id;
    }
    
    private EntityL()
    {
        
    }
}