namespace EfcMappingExamples.Cases.NullableMultiValuedValueObject;

public class EntityQ
{
    public Guid Id { get; }
    internal ValueObjectQ? someValue;

    public EntityQ(Guid id)
    {
        Id = id;
    }

    public void SetValue(ValueObjectQ v) => someValue = v;
}

public class ValueObjectQ
{
    public string? First { get; }
    public int? Second { get; }

    public static ValueObjectQ Create(string? first, int? second) 
        => new ValueObjectQ(first, second);
    private ValueObjectQ(string? first, int? second) 
        => (First, Second) = (first, second);
    
    private ValueObjectQ(){}
}

