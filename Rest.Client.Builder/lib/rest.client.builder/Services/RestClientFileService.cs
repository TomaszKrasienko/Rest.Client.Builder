using rest.client.builder.Searchers.Abstractions;
using rest.client.builder.Services.Abstractions;

namespace rest.client.builder.Services;

internal sealed class RestClientFileService : IRestClientFileService
{
    private const string _urlAddress = "http://localhost:5226";
    private const string _fileName = "";
    private readonly IAssembliesSearcher _assembliesSearcher;
    private readonly IControllerSearcher _controllerSearcher;
    
    public RestClientFileService(IAssembliesSearcher assembliesSearcher, IControllerSearcher controllerSearcher)
    {
        _assembliesSearcher = assembliesSearcher;
        _controllerSearcher = controllerSearcher;
    }
    
    public void Execute()
    {
        //get all assemblies
        var assemblies = _assembliesSearcher.GetAllAssemblies();
        var controllers = _controllerSearcher.GetAllControllersFromAssemblies(assemblies);
        //search all controllers

        //get controller path => route attribute

        //from each controller get method with routing attribute
    }
}