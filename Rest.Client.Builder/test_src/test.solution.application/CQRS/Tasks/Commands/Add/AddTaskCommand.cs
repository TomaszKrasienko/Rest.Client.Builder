using MediatR;

namespace test.solution.application.CQRS.Tasks.Commands.Add;

public sealed record AddTaskCommand(Guid Id, string Message) : IRequest;