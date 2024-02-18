using MediatR;
using test.solution.application.Service;

namespace test.solution.application.CQRS.Tasks.Commands.Accept;

internal sealed class AcceptTaskCommandHandler : IRequestHandler<AcceptTaskCommand>
{
    private readonly ITasksService _tasksService;

    public AcceptTaskCommandHandler(ITasksService tasksService)
        => _tasksService = tasksService;

    public Task Handle(AcceptTaskCommand request, CancellationToken cancellationToken)
    {
        _tasksService.Accept(request.Id);
        return Task.CompletedTask;
    }
}