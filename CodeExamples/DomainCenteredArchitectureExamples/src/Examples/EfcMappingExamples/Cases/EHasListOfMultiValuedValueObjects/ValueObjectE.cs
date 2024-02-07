namespace EfcMappingExamples.Cases.EHasListOfMultiValuedValueObjects;

public class ValueObjectE
{
    public string FirstValue { get; }
    public int SecondValue { get; }

    public static ValueObjectE Create(string first, int second)
        => new(first, second);

    private ValueObjectE(string firstValue, int secondValue)
        => (FirstValue, SecondValue) = (firstValue, secondValue);


    private ValueObjectE() // EFC
    {
    }

    protected bool Equals(ValueObjectE other)
    {
        return FirstValue == other.FirstValue && SecondValue == other.SecondValue;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((ValueObjectE)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(FirstValue, SecondValue);
    }
}