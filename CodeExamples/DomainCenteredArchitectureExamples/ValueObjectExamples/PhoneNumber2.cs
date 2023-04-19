namespace ValueObjectExamples;

public class PhoneNumber2 : Value<PhoneNumber2>
{
    public string Number { get; private set; }

    public string CountryCode { get; private set; }

    public PhoneNumber2(string countryCode, string number)
    {
        CountryCode = countryCode;
        Number = number;
        Validate();
    }

    private void Validate() { /* ... */ }
    protected override bool ConcreteEquals(PhoneNumber2 other)
    {
        return Number.Equals(other.Number) 
               && CountryCode.Equals(other.CountryCode);
    }
}