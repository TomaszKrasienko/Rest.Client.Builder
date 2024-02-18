namespace test.solution.application.Models;

public sealed class TodoTask
{
    public Guid Id { get; set; }
    public string Message { get; set; }
    public string Status { get; set; }
    public string RejectMessage { get; set; }
}