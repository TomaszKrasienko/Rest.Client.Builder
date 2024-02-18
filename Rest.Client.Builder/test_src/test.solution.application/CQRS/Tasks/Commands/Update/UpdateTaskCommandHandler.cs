using MediatR;
using test.solution.application.Service;

namespace test.solution.application.CQRS.Tasks.Commands.Update;

internal sealed class UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommand>
{
    private readonly ITasksService _tasksService;

    public UpdateTaskCommandHandler(ITasksService tasksService)
        => _tasksService = tasksService;
    
    public Task Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
    {
        _tasksService.Update(request.Id, request.Message);
        return Task.CompletedTask;
    }
}