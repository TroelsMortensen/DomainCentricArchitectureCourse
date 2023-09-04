using OperationResult;

namespace DomainBlocks;

public record Password
{
    public string Value { get; }
    
    internal string TestString { get; }
    
    private Password(string input)
    {
        Value = input;
    }

    public static Result<Password> Create(string input)
    {
        List<string> errors = Validate(input);

        return errors.Any() ? new Result<Password>(errors) : new Result<Password>(new Password(input));
    }

    private static List<string> Validate(string input)
    {
        List<string> errors = new();
        if (string.IsNullOrEmpty(input)) errors.Add("Password cannot be empty");
        if (input.Length < 8) errors.Add("Password must be at least 8 characters");
        if (input.Length > 24) errors.Add("Password must be at most 24 characters");

        return errors;
    }
}