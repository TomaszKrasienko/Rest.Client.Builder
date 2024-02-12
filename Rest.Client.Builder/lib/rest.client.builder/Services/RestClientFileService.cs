using rest.client.builder.Models;
using rest.client.builder.OpenApi.Communication.Clients.Abstractions;
using rest.client.builder.OpenApi.Models;
using rest.client.builder.Services.Abstractions;

namespace rest.client.builder.Services;

internal sealed class RestClientFileService : IRestClientFileService
{
    private readonly IOpenApiClient _openApiClient;

    public RestClientFileService(IOpenApiClient openApiClient)
    {
        _openApiClient = openApiClient;
    }

    public async Task Execute()
    {
        var openApiDoc = await _openApiClient.GetOpenApiDocumentation();
        List<GetRequest> getRequestsList = new List<GetRequest>();
        foreach (var path in openApiDoc.Paths)
        {
            if (path.Value.Get is not null)
            {
                var getRequest = HandleGet(path.Key, path.Value.Get);
                getRequestsList.Add(getRequest);
            }
        }
    }

    private GetRequest HandleGet(string path, GetDoc getDoc)
    {
        GetRequest request = new GetRequest();
        request.Path = path;
        if (getDoc.Parameters is not null)
        {
            request.Parameters = new Dictionary<string, string>();
            foreach (var param in getDoc.Parameters)
            {
                request.Parameters.Add(param.Name, param.In);
            }
        }
        return request;
    }
    
    
}