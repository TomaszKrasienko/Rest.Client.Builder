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
    
    [HttpGet("parameter-in-route/{id:guid}")]
    public ActionResult<TestDataDto> GetById(Guid id)
        => Ok(_testDataService.Get(id));
    
    [HttpGet("parameter-in-query")]
    public ActionResult<TestDataDto> GetByIdQuery(Guid id)
        => Ok(_testDataService.Get(id));
    
    [HttpPost]
    public ActionResult Add(application.Commands.AddTestDataCommand command)
    {
        _testDataService.Add(command);
        return Ok();
    }
    
    [HttpPost("{id:guid}/parameter-in-route")]
    public ActionResult AddParameterInRoute(Guid id, AddTestDataCommand command)
    {
        _testDataService.Add(command);
        return Ok();
    }
    
    [HttpPost("parameter-in-query")]
    public ActionResult AddParameterInQuery(Guid id, AddTestDataCommand command)
    {
        _testDataService.Add(command);
        return Ok();
    }
}