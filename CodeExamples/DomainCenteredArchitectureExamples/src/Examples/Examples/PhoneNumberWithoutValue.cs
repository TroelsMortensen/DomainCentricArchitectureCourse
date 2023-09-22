namespace Examples;

public class PhoneNumberWithoutValue
{
    public string Number { get; private set; }

    public string CountryCode { get; private set; }

    public PhoneNumberWithoutValue(string countryCode, string number)
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
        if (!(obj is PhoneNumberWithoutValue)) return false;
        PhoneNumberWithoutValue other = (PhoneNumberWithoutValue)obj;
        return Number.Equals(other.Number) 
               && CountryCode.Equals(other.CountryCode);
    }

    public static bool operator ==(PhoneNumberWithoutValue left, PhoneNumberWithoutValue right)
    {
        if (ReferenceEquals(null, right)) return false; 
        if (ReferenceEquals(null, left)) return false;
        return left.Equals(right);
    }

    public static bool operator !=(PhoneNumberWithoutValue left, PhoneNumberWithoutValue right)
    {
        return !(left == right);
    }
}