using MediatR;

namespace test.solution.application.CQRS.Tasks.Commands.Accept;

public sealed record AcceptTaskCommand(Guid Id) : IRequest;