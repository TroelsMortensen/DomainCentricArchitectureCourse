namespace EfcMappingExamples.Cases.GuidAsFk;

public class EntityU
{
    public Guid Id { get; }

    internal Guid entityVId;
    
    public EntityU(Guid id)
    {
        Id = id;
    }
    
    public void SetEntityVId(Guid id) => entityVId = id;
}