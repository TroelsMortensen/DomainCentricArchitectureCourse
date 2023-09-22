using System.Text.RegularExpressions;
using DCAExamples.Core.Domain.Common.Exceptions;

namespace DCAExamples.Core.Domain.Common.Values;

public class Email
{
    public string Value { get; init; }

    public Email(string value)
    {
        Value = value;
        Validate();
    }

    private void Validate()
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


