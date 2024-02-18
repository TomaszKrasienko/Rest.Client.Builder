using MediatR;
using test.solution.application.Models;
using test.solution.application.Service;

namespace test.solution.application.CQRS.Tasks.Queries.GetAll;

internal sealed class GetAllQueryHandler : IRequestHandler<GetAllQuery, List<TodoTask>>
{
    private readonly ITasksService _tasksService;

    public GetAllQueryHandler(ITasksService tasksService)
        => _tasksService = tasksService;
    
    public Task<List<TodoTask>> Handle(GetAllQuery request, CancellationToken cancellationToken)
    {
        var tasks = _tasksService.GetAll();
        return Task.FromResult(tasks);
    }
}