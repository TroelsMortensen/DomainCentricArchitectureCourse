using DCAExamples.Core.Domain.Common.OperationResult;

namespace OperationResult;

public class Order
{
    private Order(Name firstname, Name lastname, Email email, Phone phone, Address address)
    {
        throw new NotImplementedException();
    }

    public static Result<Order> Create(Name firstname, Name lastname, Email email, Phone phone, Address address)
    {
        Result validationResult = Validate(firstname, lastname, email, phone, address);
        if (validationResult.HasErrors) return Result.Failure<Order>(validationResult.ErrorMessage);
        Order order = new Order(firstname, lastname, email, phone, address);
        return Result.Success(order);
    }

    private static Result Validate(Name firstname, Name lastname, Email email, Phone phone, Address address)
    {
        if (firstname is null) return Result.Failure("First name is required");
        if (lastname is null) return Result.Failure("Last name is missing");
        if (email is null) return Result.Failure("Email is missing");
        if (phone is null) return Result.Failure("Phone is missing");
        if (CountryCodeValidator.IsValid(phone.CountryCode)) return Result.Failure("Invalid country code");
        if (PhoneValidator.CountryCodeMatchesLengthOfNumber(phone.CountryCode, phone.Number))
            return Result.Failure("The provided country code and the length of the phone number do not match");
        if (AddressValidator.PostCodeAndCityMatches(address.PostCode, address.City))
            return Result.Failure("The post code of does not match the city name");
        return Result.Success();
    }
}

internal class AddressValidator
{
    public static bool PostCodeAndCityMatches(object postCode, object city)
    {
        throw new NotImplementedException();
    }
}

internal class PhoneValidator
{
    public static bool CountryCodeMatchesLengthOfNumber(int phoneCountryCode, object phoneNumber)
    {
        throw new NotImplementedException();
    }
}

internal class CountryCodeValidator
{
    public static bool IsValid(int phoneCountryCode)
    {
        throw new NotImplementedException();
    }
}

public class Address
{
    public object PostCode { get; set; }
    public object City { get; set; }
}

public class Phone
{
    public int CountryCode { get; set; }
    public object Number { get; set; }
}

public class Email
{
}

public class Name
{
}