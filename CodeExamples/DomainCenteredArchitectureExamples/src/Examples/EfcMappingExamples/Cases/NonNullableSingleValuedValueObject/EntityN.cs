namespace EfcMappingExamples.Cases.NonNullableSingleValuedValueObject;

public class EntityN
{
    public Guid Id { get; }

    internal ValueObjectN someValue;
    
    public EntityN(Guid id)
    {
        Id = id;
    }

    public void SetValue(ValueObjectN v) => someValue = v;
}

public class ValueObjectN
{
    public string Value { get; }

    public static ValueObjectN Create(string input) => new ValueObjectN(input);
    private ValueObjectN(string input) => Value = input;
    private ValueObjectN(){}
}