using MediatR;
using test.solution.application.Service;

namespace test.solution.application.CQRS.Tasks.Commands.Reject;

internal sealed class RejectTaskCommandHandler : IRequestHandler<RejectTaskCommand>
{
    private readonly ITasksService _tasksService;
    
    public RejectTaskCommandHandler(ITasksService tasksService)
        => _tasksService = tasksService;
    
    public Task Handle(RejectTaskCommand request, CancellationToken cancellationToken)
    {
        _tasksService.Reject(request.RejectMessage, request.Id);
        return Task.CompletedTask;
    }
}