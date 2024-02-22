namespace EfcMappingExamples.Cases.NonNullableMultiValuedValueObject;

public class EntityP
{
    public Guid Id { get; }
    internal ValueObjectP someValue;

    public EntityP(Guid id)
    {
        Id = id;
    }

    public void SetValue(ValueObjectP v) => someValue = v;
}

public class ValueObjectP
{
    public string First { get; }
    public int Second { get; }

    public static ValueObjectP Create(string first, int second) 
        => new ValueObjectP(first, second);
    private ValueObjectP(string first, int second) 
        => (First, Second) = (first, second);
    
    private ValueObjectP(){}
}