namespace EfcMappingExamples.Cases.AHasListOfGuidsReferencingB;

public class EntityBForeignKey(Guid FkToB)
{
    public Guid FkToB { get; } = FkToB;
    
    public static implicit operator EntityBForeignKey(Guid id) 
        => new (id);
    
    public static implicit operator Guid(EntityBForeignKey ent)
        => ent.FkToB;
}
