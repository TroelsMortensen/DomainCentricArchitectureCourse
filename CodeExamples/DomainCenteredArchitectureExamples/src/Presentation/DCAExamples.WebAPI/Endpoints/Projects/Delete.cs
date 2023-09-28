using DCAExamples.Core.Application.Common.CommandDispatcher;
using Microsoft.AspNetCore.Mvc;

namespace DCAExamples.WebAPI.Endpoints.Projects;


[ApiController]
public class Delete : ControllerBase
{
    [HttpPost("[autoroute]")]
    public async Task<ActionResult> HandleAsync(
        DeleteProjectRequest request,
        [FromServices] ICommandDispatcher dispatcher)
    {
        // create command
        // verify command
        // dispatch command
        
        return Ok();
    }
}
public record DeleteProjectRequest(Guid Id);
