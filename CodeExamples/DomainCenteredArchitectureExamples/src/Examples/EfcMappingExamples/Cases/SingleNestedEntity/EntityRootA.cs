namespace EfcMappingExamples.Cases.SingleNestedEntity;

public class EntityRootA
{
    public Guid Id { get; }

    internal EntityChildA child = null!;

    public EntityRootA(Guid id)
        => Id = id;

    private EntityRootA() // EFC
    {
    }

    public void SetChild(EntityChildA nestedEntity)
        => child = nestedEntity;
}