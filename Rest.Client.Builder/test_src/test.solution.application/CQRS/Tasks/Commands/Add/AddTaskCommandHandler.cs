using MediatR;
using test.solution.application.Models;
using test.solution.application.Service;

namespace test.solution.application.CQRS.Tasks.Commands.Add;

internal sealed class AddTaskCommandHandler : IRequestHandler<AddTaskCommand>
{
    private readonly ITasksService _tasksService;

    public AddTaskCommandHandler(ITasksService tasksService)
        => _tasksService = tasksService;
    
    public Task Handle(AddTaskCommand request, CancellationToken cancellationToken)
    {
        _tasksService.Add(new TodoTask()
        {
            Id = request.Id,
            Message = request.Message,
            Status = "New"
        });
        return Task.CompletedTask;
    }
}