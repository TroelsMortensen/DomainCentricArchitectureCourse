namespace EfcMappingExamples.Aggregates.SecondAggregate;

public class OtherTwoPropsValueObject
{
    public int Count { get; }
    public string Unit { get; }

    private OtherTwoPropsValueObject(string type, int amount)
        => (Count, Unit) = (amount, type);

    private OtherTwoPropsValueObject() // EFC
    {
    }

    public static OtherTwoPropsValueObject Create(string type, int amount)
        => new OtherTwoPropsValueObject(type, amount);

    private bool Equals(OtherTwoPropsValueObject other)
    {
        return Count == other.Count && Unit == other.Unit;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OtherTwoPropsValueObject)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Count, Unit);
    }
}