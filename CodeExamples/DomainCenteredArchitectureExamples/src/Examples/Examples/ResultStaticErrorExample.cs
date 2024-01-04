using DCAExamples.Core.Domain.Common.OperationResult;
using Void = DCAExamples.Core.Domain.Common.OperationResult.Void;

namespace Examples;

public class ResultStaticErrorExample
{
    public Result<Void> DoSomething()
    {
        if (ShouldFail())
        {
            return ProjectTaskErrors.SomeError;
        }

        return new Result<Void>(new Void());
    }

    private bool ShouldFail()
    {
        throw new NotImplementedException();
    }
}

public class ProjectTaskErrors
{
    public static Result<Void> SomeError = new Result<Void>("Some error");
}