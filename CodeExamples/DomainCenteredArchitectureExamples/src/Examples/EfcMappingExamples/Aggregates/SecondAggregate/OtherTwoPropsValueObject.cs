namespace EfcMappingExamples.Aggregates.SecondAggregate;

public class OtherTwoPropsValueObject
{
    public int Count { get;  } 
    public string Unit { get;  }

    private OtherTwoPropsValueObject(string unit, int count)
        => (Count, Unit) = (count, unit);

    private OtherTwoPropsValueObject() // EFC
    {
    }

    public static OtherTwoPropsValueObject Create(string unit, int count)
        => new OtherTwoPropsValueObject(unit, count);

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