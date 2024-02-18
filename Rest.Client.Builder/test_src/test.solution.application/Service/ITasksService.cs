using test.solution.application.Models;

namespace test.solution.application.Service;

public interface ITasksService
{
    List<TodoTask> GetAll();
    TodoTask GetById(Guid id);
    void Add(TodoTask task);
    void Update(Guid id, string message);
    void Delete(Guid id);
    void Accept(Guid id);
    void Reject(string rejectMessage, Guid id);
}