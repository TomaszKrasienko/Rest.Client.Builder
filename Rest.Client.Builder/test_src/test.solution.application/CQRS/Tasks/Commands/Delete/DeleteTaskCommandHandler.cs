using MediatR;
using test.solution.application.Service;

namespace test.solution.application.CQRS.Tasks.Commands.Delete;

internal sealed class DeleteTaskCommandHandler : IRequestHandler<DeleteTaskCommand>
{
    private readonly ITasksService _tasksService;

    public DeleteTaskCommandHandler(ITasksService tasksService)
        => _tasksService = tasksService;
    
    public Task Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
    {
        _tasksService.Delete(request.Id);
        return Task.CompletedTask;
    }
}