using test.solution.application.Commands;
using test.solution.application.DTO;

namespace test.solution.application.Services;

public interface ITestDataService
{
    void Add(AddTestDataCommand command);
    TestDataDto Get(Guid id);
    List<TestDataDto> GetAll();
}