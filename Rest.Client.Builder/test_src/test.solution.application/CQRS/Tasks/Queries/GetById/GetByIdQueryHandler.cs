using MediatR;
using test.solution.application.Models;
using test.solution.application.Service;

namespace test.solution.application.CQRS.Tasks.Queries.GetById;

internal sealed class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, TodoTask>
{
    private readonly ITasksService _tasksService;

    public GetByIdQueryHandler(ITasksService tasksService)
        => _tasksService = tasksService;
    
    public Task<TodoTask> Handle(GetByIdQuery request, CancellationToken cancellationToken)
    {
        var todoTask = _tasksService.GetById(request.Id);
        return Task.FromResult(todoTask);
    }
}