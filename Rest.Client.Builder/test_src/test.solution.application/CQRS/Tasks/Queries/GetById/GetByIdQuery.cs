using MediatR;
using test.solution.application.Models;

namespace test.solution.application.CQRS.Tasks.Queries.GetById;

public sealed record GetByIdQuery(Guid Id) : IRequest<TodoTask>;