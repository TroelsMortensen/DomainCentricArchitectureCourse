namespace EfcMappingExamples.Cases.NullableNestedValueObjects;

public class EntityS
{
    public Guid Id { get; }

    internal ValueObjectS? someValue;

    public EntityS(Guid id)
        => Id = id;
    
    public void SetValue(ValueObjectS v) => someValue = v;
    
    private EntityS()
    {
    }
}

public class ValueObjectS
{
    public NestedValueObjectS1? First { get; }
    public NestedValueObjectS2? Second { get; }

    public static ValueObjectS Create(NestedValueObjectS1? first, NestedValueObjectS2? second)
        => new ValueObjectS(first, second);

    private ValueObjectS(NestedValueObjectS1? first, NestedValueObjectS2? second)
        => (First, Second) = (first, second);

    private ValueObjectS()
    {
    }
}

public class NestedValueObjectS1
{
    public string? Value { get; }

    public static NestedValueObjectS1 Create(string? input)
        => new NestedValueObjectS1(input);

    private NestedValueObjectS1(string? input)
        => Value = input;

    private NestedValueObjectS1()
    {
    }
}

public class NestedValueObjectS2
{
    public int? Value { get; }

    public static NestedValueObjectS2 Create(int? input)
        => new NestedValueObjectS2(input);

    private NestedValueObjectS2(int? input)
        => Value = input;

    private NestedValueObjectS2()
    {
    }
}