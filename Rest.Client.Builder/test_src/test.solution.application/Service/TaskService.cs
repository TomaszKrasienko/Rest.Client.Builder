using test.solution.application.Models;

namespace test.solution.application.Service;

internal sealed class TasksService : ITasksService
{
    private readonly List<TodoTask> _tasks;

    public TasksService()
        => _tasks = new List<TodoTask>();

    public List<TodoTask> GetAll()
        => _tasks;

    public TodoTask GetById(Guid id)
        => _tasks.FirstOrDefault(x => x.Id == id);

    public void Add(TodoTask task)
        => _tasks.Add(task);

    public void Update(Guid id, string message)
    {
        var task = GetById(id);
        if (task is not null)
        {
            task.Message = message;
        }
    }

    public void Delete(Guid id)
        => _tasks.Remove(_tasks.Single(x => x.Id == id));

    public void Accept(Guid id)
    {        
        var task = GetById(id);
        if (task is not null)
        {
            task.Status = "accepted";
        }
    }

    public void Reject(string rejectMessage, Guid id)
    {        
        var task = GetById(id);
        if (task is not null)
        {
            task.Status = "rejected";
            task.RejectMessage = rejectMessage;
        }
    }
}