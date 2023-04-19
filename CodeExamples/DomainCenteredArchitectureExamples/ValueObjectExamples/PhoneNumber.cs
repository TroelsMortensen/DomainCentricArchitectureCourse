namespace ValueObjectExamples;

public class PhoneNumber
{
    public string Number { get; private set; }

    public string CountryCode { get; private set; }

    public PhoneNumber(string countryCode, string number)
    {
        CountryCode = countryCode;
        Number = number;
        Validate();
    }

    private void Validate()
    {
        //...
    }

    public override bool Equals(object? obj)
    {
        if (obj == null) return false;
        if (!(obj is PhoneNumber)) return false;
        PhoneNumber other = (PhoneNumber)obj;
        return Number.Equals(other.Number) 
               && CountryCode.Equals(other.CountryCode);
    }

    public static bool operator ==(PhoneNumber left, PhoneNumber right)
    {
        if (ReferenceEquals(null, right)) return false; 
        if (ReferenceEquals(null, left)) return false;
        return left.Equals(right);
    }

    public static bool operator !=(PhoneNumber left, PhoneNumber right)
    {
        return !(left == right);
    }
}