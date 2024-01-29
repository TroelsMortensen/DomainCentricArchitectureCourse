namespace EfcMappingExamples.Aggregates.FirstAggregate;

public class MyStringValueObject
{
    // name argument the same as property, case-insensitive.
    // Then EFC can figure out to use this constructor.
    // Alternatively, you need a private no-arguments constructor
    private MyStringValueObject(string value)
        => Value = value;

    public string Value { get; }

    public static MyStringValueObject Create(string input)
    {
        return new MyStringValueObject(input);
    }

    // I don't need this private constructor, because my other constructor takes an argument, which name matches the property name.
    // private MyStringValueObject()
    // {
    // }

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