using MediatR;

namespace test.solution.application.CQRS.Tasks.Commands.Update;

public record UpdateTaskCommand(Guid Id, string Message) : IRequest;