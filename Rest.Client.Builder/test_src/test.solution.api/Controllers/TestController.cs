using MediatR;
using Microsoft.AspNetCore.Mvc;
using test.solution.application.CQRS.Tasks.Commands.Accept;
using test.solution.application.CQRS.Tasks.Commands.Add;
using test.solution.application.CQRS.Tasks.Commands.Delete;
using test.solution.application.CQRS.Tasks.Commands.Reject;
using test.solution.application.CQRS.Tasks.Commands.Update;
using test.solution.application.CQRS.Tasks.Queries.GetAll;
using test.solution.application.CQRS.Tasks.Queries.GetById;
using test.solution.application.Models;

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
    
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<TodoTask>> GetById(Guid id)
        => Ok(await _mediator.Send(new GetByIdQuery(id)));

    [HttpGet]
    public async Task<ActionResult<TodoTask>> GetAll()
        => Ok(await _mediator.Send(new GetAllQuery()));

    [HttpPost]
    public async Task<ActionResult> AddTask(AddTaskCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpPatch("{acceptTaskId:guid}/accept-task")]
    public async Task<ActionResult> AcceptTask(Guid acceptTaskId)
    {
        await _mediator.Send(new AcceptTaskCommand(acceptTaskId));
        return NoContent();
    }
    
    [HttpPatch("{rejectTaskId:guid}/reject-task")]
    public async Task<ActionResult> RejectTask(Guid rejectTaskId, RejectTaskCommand command)
    {
        await _mediator.Send(command with {Id = rejectTaskId});
        return NoContent();
    }

    [HttpPut("update/{updateTaskId:guid}")]
    public async Task<ActionResult> UpdateTask(Guid updateTaskId, UpdateTaskCommand command)
    {
        await _mediator.Send(command with { Id = updateTaskId });
        return NoContent();
    }
    
    [HttpDelete("delete/{deleteTaskId:guid}")]
    public async Task<ActionResult> UpdateTask(Guid deleteTaskId)
    {
        await _mediator.Send(new DeleteTaskCommand(deleteTaskId));
        return NoContent();
    }
}