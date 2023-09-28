using DCAExamples.Core.Application.Common.CommandDispatcher;
using Microsoft.AspNetCore.Mvc;

namespace DCAExamples.WebAPI.REPRBase;
public static class EndpointBase
{
    public static class WithRequest<TRequest>
    {
        public abstract class WithResponse<TResponse> : EPB
        {
            public abstract Task<ActionResult<TResponse>> HandleAsync(TRequest request, ICommandDispatcher dispatcher);
        }

        public abstract class WithoutResponse : EPB
        {
            public abstract Task<ActionResult> HandleAsync(TRequest request, ICommandDispatcher dispatcher);
        }
    }

    public static class WithoutRequest
    {
        public abstract class WithResponse<TResponse> : EPB
        {
            public abstract Task<ActionResult<TResponse>> HandleAsync(ICommandDispatcher dispatcher);
        }

        public abstract class WithoutResponse : EPB
        {
            public abstract Task<ActionResult> HandleAsync(ICommandDispatcher dispatcher);
        }
    }
}

[ApiController]
[Route("api")]
public abstract class EPB : ControllerBase
{
}