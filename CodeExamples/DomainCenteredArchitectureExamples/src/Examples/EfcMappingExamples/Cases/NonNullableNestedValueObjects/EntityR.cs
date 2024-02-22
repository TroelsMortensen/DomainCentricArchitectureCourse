namespace EfcMappingExamples.Cases.NonNullableNestedValueObjects;

public class EntityR
{
    public Guid Id { get; }

    internal ValueObjectR someValue;

    public EntityR(Guid id)
        => Id = id;

    public void SetValue(ValueObjectR v) => someValue = v;
}

public class ValueObjectR
{
    public NestedValueObjectR1 First { get; }
    public NestedValueObjectR2 Second { get; }

    public static ValueObjectR Create(NestedValueObjectR1 first, NestedValueObjectR2 second)
        => new ValueObjectR(first, second);

    private ValueObjectR(NestedValueObjectR1 first, NestedValueObjectR2 second)
        => (First, Second) = (first, second);

    private ValueObjectR()
    {
    }
}

public class NestedValueObjectR1
{
    public string Value { get; }

    public static NestedValueObjectR1 Create(string input)
        => new NestedValueObjectR1(input);

    private NestedValueObjectR1(string input)
        => Value = input;

    private NestedValueObjectR1()
    {
    }
}

public class NestedValueObjectR2
{
    public int Value { get; }

    public static NestedValueObjectR2 Create(int input)
        => new NestedValueObjectR2(input);

    private NestedValueObjectR2(int input)
        => Value = input;

    private NestedValueObjectR2()
    {
    }
}