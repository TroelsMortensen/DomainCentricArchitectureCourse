namespace EfcMappingExamples.Aggregates.SecondAggregate;

public class TwoPropsValueObject
{
    public int Amount { get; }
    public string Type { get; }

    private TwoPropsValueObject(string type, int amount)
        => (Amount, Type) = (amount, type);

    private TwoPropsValueObject() // EFC
    {
    }

    public static TwoPropsValueObject Create(string type, int amount)
        => new TwoPropsValueObject(type, amount);

    private bool Equals(TwoPropsValueObject other)
    {
        return Amount == other.Amount && Type == other.Type;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((TwoPropsValueObject)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Amount, Type);
    }
}