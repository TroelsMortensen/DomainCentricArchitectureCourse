namespace EfcMappingExamples.Aggregates.FirstAggregate;

public class MyStringValueObject
{
    private MyStringValueObject(string input)
        => Value = input;

    public string Value { get; }

    public static MyStringValueObject Create(string input)
    {
        return new MyStringValueObject(input);
    }
}