using DCAExamples.Core.Domain.Common.Bases;

namespace DCAExamples.Core.Domain.Common.Values;

public class PhoneNumber : ValueObject
{
    public string Number { get; private set; }

    public string CountryCode { get; private set; }

    public PhoneNumber(string countryCode, string number)
    {
        CountryCode = countryCode;
        Number = number;
        Validate();
    }

    private void Validate() { /* ... */ }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Number;
        yield return CountryCode;
    }
}