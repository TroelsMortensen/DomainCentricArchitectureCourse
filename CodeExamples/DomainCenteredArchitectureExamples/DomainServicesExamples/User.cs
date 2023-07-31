using OperationResult;

namespace DomainServicesExamples;

public class User : Entity
{
    private Username username;
    
    private User(Username username)
    {
        this.username = username;
    }

    public static Result<User> Create(Username username, IProfanityChecker profanityChecker)
    {
        if (profanityChecker.ContainsProfanity(username.Value))
        {
            return new Result<User>("User name contains profanity");
        }

        return new(new User(username));
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