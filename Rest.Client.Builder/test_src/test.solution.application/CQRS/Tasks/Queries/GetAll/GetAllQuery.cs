using MediatR;
using test.solution.application.Models;

namespace test.solution.application.CQRS.Tasks.Queries.GetAll;

public record GetAllQuery() : IRequest<List<TodoTask>>;