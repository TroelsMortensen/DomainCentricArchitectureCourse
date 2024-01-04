using DCAExamples.Core.Application.Common.CommandDispatcher;
using Microsoft.AspNetCore.Mvc;
using Endpoint = DCAExamples.WebAPI.REPRBase.Endpoint;

namespace DCAExamples.WebAPI.Endpoints.Projects;

public class Create : Endpoint
    .WithRequest<CreateProjectRequest>
    .WithResponse<CreateProjectResponse>
{
    private readonly ICommandDispatcher dispatcher;

    public Create(ICommandDispatcher dispatcher)
    {
        this.dispatcher = dispatcher;
    }

    [HttpPost("/projects/create")]
    public override async Task<ActionResult<CreateProjectResponse>> HandleAsync(
        CreateProjectRequest request)
    {
        // convert request to command
        // check command is valid
        // dispatch command
        return Ok();
    }
}

public record CreateProjectRequest(string Title);

public record CreateProjectResponse(Guid id);