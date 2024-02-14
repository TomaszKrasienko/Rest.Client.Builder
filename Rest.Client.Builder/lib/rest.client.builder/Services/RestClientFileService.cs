using Newtonsoft.Json;
using rest.client.builder.Builders.Abstractions;
using rest.client.builder.FileWriting.Abstractions;
using rest.client.builder.Models;
using rest.client.builder.OpenApi.Communication.Clients.Abstractions;
using rest.client.builder.OpenApi.Models;
using rest.client.builder.Services.Abstractions;

namespace rest.client.builder.Services;

internal sealed class RestClientFileService : IRestClientFileService
{
    private readonly IOpenApiClient _openApiClient;
    private readonly IRestClientFileBuilder _restClientFileBuilder;
    private readonly IFileWriter _fileWriter;
    public RestClientFileService(IOpenApiClient openApiClient, IRestClientFileBuilder restClientFileBuilder, IFileWriter fileWriter)
    {
        _openApiClient = openApiClient;
        _restClientFileBuilder = restClientFileBuilder;
        _fileWriter = fileWriter;
    }

    public async Task Execute()
    {
        var openApiDoc = await _openApiClient.GetOpenApiDocumentation();
        _restClientFileBuilder.SetAddress("http://localhost:5226");
        List<GetRequest> getRequestsList = new List<GetRequest>();
        foreach (var path in openApiDoc.Paths)
        {
            if (path.Value.Get is not null)
            {
                var getRequest = HandleGet(path.Key, path.Value.Get);
                getRequestsList.Add(getRequest);
            }

            if (path.Value.Post is not null)
            {
                var postRequest = HandlePost(path.Key, path.Value.Post);
            }
        }
        _restClientFileBuilder.SetGetRequests(getRequestsList);
        string fileContent = _restClientFileBuilder.Build();
        _fileWriter.Write(fileContent);
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
    
    private PostRequest HandlePost(string path, PostDoc postDoc)
    {
        PostRequest request = new PostRequest();
        request.Path = path;
        request.Reference = postDoc.RequestBody.Content.ApplicationJson.Schema.@ref;
        request.ContentType = "application/json";
    }
    
    
}