using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using test.solution.application.CQRS.Tasks.Commands.Add;

namespace test.solution.api.Controllers;

[ApiController]
[Route("[controller]")]
public sealed class TestController : ControllerBase
{
    private readonly IMediator _mediator;

    public TestController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public ActionResult AddTask(AddTaskCommand command)
    {
        _mediator.Send(command);
        return NoContent();
    }
}