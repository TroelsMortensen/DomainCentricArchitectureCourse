using System.ComponentModel;
using DCAExamples.Core.Application.Common.CommandDispatcher;
using Microsoft.AspNetCore.Mvc;

namespace DCAExamples.WebAPI.Endpoints.Projects;



[ApiController]
public class Create : ControllerBase
{

    [HttpPost("[autoroute]")]
    public async Task<ActionResult<CreateProjectResponse>> HandleAsync(
        CreateProjectRequest request,
        [FromServices] ICommandDispatcher dispatcher)
    {
        // convert request to command
        // check command is valid
        // dispatch command
        return Ok(new CreateProjectResponse(Guid.NewGuid()));
    }
}
public record CreateProjectRequest(string Title);
public record CreateProjectResponse(Guid id);