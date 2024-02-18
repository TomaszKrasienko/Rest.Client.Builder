using MediatR;

namespace test.solution.application.CQRS.Tasks.Commands.Reject;

public sealed record RejectTaskCommand(Guid Id, string RejectMessage) : IRequest;