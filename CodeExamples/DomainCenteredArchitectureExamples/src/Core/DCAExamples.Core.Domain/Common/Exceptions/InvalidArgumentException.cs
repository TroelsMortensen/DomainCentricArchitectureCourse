namespace DCAExamples.Core.Domain.Common.Exceptions;

public class InvalidArgumentException : Exception
{
    public InvalidArgumentException(string message) : base(message)
    {
    }
}