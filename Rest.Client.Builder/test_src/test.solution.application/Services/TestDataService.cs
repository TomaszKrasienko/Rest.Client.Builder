using test.solution.application.Commands;
using test.solution.application.DTO;

namespace test.solution.application.Services;

public sealed class TestDataService : ITestDataService
{
    private List<TestDataDto> _data = new List<TestDataDto>();

    public void Add(Commands.AddTestDataCommand command)
        => _data.Add(new TestDataDto()
        {
            Id = Guid.NewGuid(),
            Name = command.Name,
            Description = command.Description
        });

    public TestDataDto Get(Guid id)
        => _data.FirstOrDefault(x => x.Id == id);

    public List<TestDataDto> GetAll()
        => _data;
}