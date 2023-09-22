using DCAExamples.Core.Domain.Common.OperationResult;

namespace DCAExamples.Core.Domain.Common.Values;

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

public class Entity
{
    private User user;

    public void method()
    {
        User.Create(new(""), null);
    }
}