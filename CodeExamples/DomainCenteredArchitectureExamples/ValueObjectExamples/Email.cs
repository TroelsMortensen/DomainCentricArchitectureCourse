using System.ComponentModel;
using System.Text.RegularExpressions;

namespace ValueObjectExamples;

public class Email
{
    public string Value { get; private set; }

    public Email(string value)
    {
        Value = value;
        validate();
    }

    private void validate()
    {
        Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        Match match = regex.Match(Value);
        if (!match.Success)
        {
            throw new InvalidArgumentException("Is not correct format");
        }

        if (!Value.Contains("@via.dk", StringComparison.OrdinalIgnoreCase))
        {
            throw new InvalidArgumentException("Is not VIA email");
        }
    }

    public override bool Equals(object? obj)
    {
        if (!(obj is Email))
        {
            return false;
        }

        Email email = (Email)obj;
        return Value.Equals(email.Value);
    }
}

public class InvalidArgumentException : Exception
{
    public InvalidArgumentException(string message) : base(message)
    {
    }
}
public class SystemFailure : Exception
{
    public SystemFailure(string message) : base(message)
    {
    }
}