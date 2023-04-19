namespace ValueObjectExamples;

public abstract class Value<T> 
{
    public static bool operator ==(Value<T> left, Value<T> right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(Value<T> left, Value<T> right)
    {
        return !Equals(left, right);
    }

    public override bool Equals(object? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return ConcreteEquals((T)other);
    }

    protected abstract bool ConcreteEquals(T other);
}