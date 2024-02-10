using System.Text;
using Microsoft.AspNetCore.Mvc;
using rest.client.builder.Searchers.Abstractions;
using rest.client.builder.Services.Abstractions;

namespace rest.client.builder.Services;

internal sealed class RestClientFileService : IRestClientFileService
{
    private StringBuilder fileContent = new StringBuilder(); 
    private const string _urlAddress = "http://localhost:5226";
    private const string _fileName = "";
    private readonly IAssembliesSearcher _assembliesSearcher;
    private readonly IControllerSearcher _controllerSearcher;
    private readonly IControllerHandler _controllerHandler;
    
    public RestClientFileService(IAssembliesSearcher assembliesSearcher, IControllerSearcher controllerSearcher, IControllerHandler controllerHandler)
    {
        _assembliesSearcher = assembliesSearcher;
        _controllerSearcher = controllerSearcher;
        _controllerHandler = controllerHandler;
    }
    
    public void Execute()
    {
        //add url variable
        fileContent = fileContent.AppendLine($"@url={_urlAddress}");
        //get all assemblies
        var assemblies = _assembliesSearcher.GetAllAssemblies();
        //search all controllers
        var controllers = _controllerSearcher.GetAllControllersFromAssemblies(assemblies);

        //get controller path => route attribute
        foreach (var controller in controllers)
        {
            _controllerHandler.HandleController(controller, fileContent);
        }
        
        //from each controller get method with routing attribute
    }
    
}