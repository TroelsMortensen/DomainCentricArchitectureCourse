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

    private MyStringValueObject() // EFC
    {
        
    }

    private bool Equals(MyStringValueObject other)
    {
        return Value == other.Value;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((MyStringValueObject)obj);
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }
}