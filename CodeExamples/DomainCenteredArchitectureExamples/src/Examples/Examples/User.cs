using DCAExamples.Core.Domain.Common.Bases;
using DCAExamples.Core.Domain.Common.OperationResult;

namespace Examples;

public class User : Entity
{
    internal Username username { get; private set; }

    public static Result<User> Create(Username username, IProfanityChecker profanityChecker)
    {
        if (profanityChecker.ContainsProfanity(username.Value))
        {
            return new Result<User>("User name contains profanity");
        }

        return new(new User(username));
    }

    private User(Username username)
    {
        this.username = username;
    }

    // .. the rest of the stuff
}

public record Username(string Value)
{
    
}

public interface IProfanityChecker
{
    bool ContainsProfanity(string text);
}

