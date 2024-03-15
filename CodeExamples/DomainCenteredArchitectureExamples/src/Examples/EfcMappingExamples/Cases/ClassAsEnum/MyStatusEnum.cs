namespace EfcMappingExamples.Cases.ClassAsEnum;

public class MyStatusEnum
{
    public static MyStatusEnum First { get; } = new("First");
    public static MyStatusEnum Second { get; } = new("Second");
    public static MyStatusEnum Third { get; } = new("Third");

    private readonly string backingValue;

    private MyStatusEnum(string value)
        => backingValue = value;

    private MyStatusEnum()
    {
    }

    private bool Equals(MyStatusEnum other)
        => backingValue == other.backingValue;

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((MyStatusEnum)obj);
    }

    public override int GetHashCode()
        => backingValue.GetHashCode();
}