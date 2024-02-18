using MediatR;

namespace test.solution.application.CQRS.Tasks.Commands.Delete;

public sealed record DeleteTaskCommand(Guid Id) : IRequest;