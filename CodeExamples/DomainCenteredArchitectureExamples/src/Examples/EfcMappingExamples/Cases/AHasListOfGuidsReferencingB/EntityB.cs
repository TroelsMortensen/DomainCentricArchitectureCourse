namespace EfcMappingExamples.Cases.AHasListOfGuidsReferencingB;

public class EntityB
{
    public Guid Id { get; }

    public EntityB(Guid id)
    {
        Id = id;
    }
    //
    // private EntityB()
    // {
    //     
    // }
}