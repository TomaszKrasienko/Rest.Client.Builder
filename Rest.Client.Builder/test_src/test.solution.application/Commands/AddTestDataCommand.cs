using test.solution.application.DTO;

namespace test.solution.application.Commands;

public record AddTestDataCommand(string Name, string Description /*, ParameterDto ParameterDto, List<ParameterDto> Parameters*/);