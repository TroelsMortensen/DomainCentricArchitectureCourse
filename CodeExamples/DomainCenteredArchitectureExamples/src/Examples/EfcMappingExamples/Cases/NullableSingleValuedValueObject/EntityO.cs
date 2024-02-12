namespace EfcMappingExamples.Cases.NullableSingleValuedValueObject;

public class EntityO
{
    public Guid Id { get; }

    internal ValueObjectO? someValue;
    
    public EntityO(Guid id)
    {
        Id = id;
    }

    public void SetValue(ValueObjectO v) => someValue = v;
}