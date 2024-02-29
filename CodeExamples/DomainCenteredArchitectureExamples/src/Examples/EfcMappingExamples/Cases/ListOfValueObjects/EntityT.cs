namespace EfcMappingExamples.Cases.ListOfValueObjects;

public class EntityT
{
    public Guid Id { get; }
    internal List<ValueObjectT> someValues;
    
    public EntityT(Guid id)
    {
        Id = id;
        someValues = new();
    }
    
    public void AddValue(ValueObjectT v) => someValues.Add(v);
}

public class ValueObjectT
{
    public string Value { get; }

    public static ValueObjectT Create(string value) => new(value);

    private ValueObjectT(string value)
        => Value = value;

    private ValueObjectT()
    {
    }
}