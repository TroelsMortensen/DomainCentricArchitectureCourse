namespace EfcMappingExamples.Cases.NestedValueObjects;

public class EntityJ
{
    public Guid Id { get; }

    internal TopValueObject myValue;
    
    public EntityJ(Guid id)
    {
        Id = id;
    }

    public void SetValue(TopValueObject value) => myValue = value;
    
    private EntityJ()
    {
    }
}