using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using test.solution.application.Commands;
using test.solution.application.DTO;
using test.solution.application.Services;

namespace test.solution.api.Controllers;

[ApiController]
[Route("[controller]")]
public sealed class TestController : ControllerBase
{
    private readonly ITestDataService _testDataService;

    public TestController(ITestDataService testDataService)
        => _testDataService = testDataService;

    [HttpGet]
    public ActionResult<List<TestDataDto>> Get()
        => Ok(_testDataService.GetAll());

    [HttpGet("{id:guid}")]
    public ActionResult<TestDataDto> GetById(Guid id)
        => Ok(_testDataService.Get(id));

    [HttpPost]
    public ActionResult Add(AddTestDataCommand command)
    {
        _testDataService.Add(command);
        return Ok();
    }
}