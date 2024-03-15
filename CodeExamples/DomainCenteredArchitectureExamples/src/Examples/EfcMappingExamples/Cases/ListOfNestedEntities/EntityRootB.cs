namespace EfcMappingExamples.Cases.ListOfNestedEntities;

public class EntityRootB
{
    public Guid Id { get; }

    internal List<EntityChildB> children = new();

    public EntityRootB(Guid id)
        => Id = id;
    
    public void AddChild(EntityChildB nestedEntity)
        => children.Add(nestedEntity);
}