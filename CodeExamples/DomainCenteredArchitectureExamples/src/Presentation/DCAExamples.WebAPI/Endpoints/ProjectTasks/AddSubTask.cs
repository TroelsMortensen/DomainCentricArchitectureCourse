using DCAExamples.Core.Application.Common.CommandDispatcher;
using Microsoft.AspNetCore.Mvc;

namespace DCAExamples.WebAPI.Endpoints.ProjectTasks;

[ApiController]
public class AddSubTask : ControllerBase
{
    [HttpPost("[autoroute]")]
    public async Task<ActionResult> HandleAsync(
        AddSubTaskRequest request,
        [FromServices] ICommandDispatcher dispatcher)
    {
        // convert request to command
        // verify valid command
        // dispatch
        return Ok();
    }
}

public record AddSubTaskRequest(string Description);