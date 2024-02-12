namespace EfcMappingExamples.Cases.NullableSingleValuedValueObject;

public class ValueObjectO
{
    public string Value { get; }

    public static ValueObjectO Create(string input) => new ValueObjectO(input);
    private ValueObjectO(string input) => Value = input;

    private ValueObjectO()
    {
    }
}