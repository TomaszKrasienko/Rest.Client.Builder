using rest.client.builder.BodyComponents.Services.Abstractions;
using rest.client.builder.Builders.Abstractions;
using rest.client.builder.FileWriting.Abstractions;
using rest.client.builder.OpenApi.Communication.Clients.Abstractions;
using rest.client.builder.OpenApi.Models;
using rest.client.builder.Requests.Mappers;
using rest.client.builder.Requests.Models;
using rest.client.builder.Services.Abstractions;

namespace rest.client.builder.Services;

internal sealed class RestClientFileService : IRestClientFileService
{
    private readonly IOpenApiClient _openApiClient;
    private readonly IRestClientFileBuilder _restClientFileBuilder;
    private readonly IFileWriter _fileWriter;
    private readonly IBodyComponentsStorage _bodyComponentsStorage;
    public RestClientFileService(IOpenApiClient openApiClient, IRestClientFileBuilder restClientFileBuilder, 
        IFileWriter fileWriter, IBodyComponentsStorage bodyComponentsStorage)
    {
        _openApiClient = openApiClient;
        _restClientFileBuilder = restClientFileBuilder;
        _fileWriter = fileWriter;
        _bodyComponentsStorage = bodyComponentsStorage;
    }

    public async Task Execute()
    {
        var openApiDoc = await _openApiClient.GetOpenApiDocumentation();
        _bodyComponentsStorage.Load(openApiDoc);
        
        _restClientFileBuilder.SetAddress("http://localhost:5226");
        foreach (var path in openApiDoc.Paths)
        {
            if (path.Value.Get is not null)
            {
                _restClientFileBuilder.SetGetRequest(path.Value.Get.AsGetRequest(path.Key));
            }

            if (path.Value.Post is not null)
            {
                var postRequest = HandlePost(path.Key, path.Value.Post);
                _restClientFileBuilder.SetPostRequest(postRequest);
            }
        }
        string fileContent = _restClientFileBuilder.Build();
        _fileWriter.Write(fileContent);
    }
    
    private PostRequest HandlePost(string path, PostDoc postDoc)
    {
        PostRequest request = new PostRequest();
        request.Path = path;
        request.Reference = postDoc.RequestBody.Content.ApplicationJson.Schema.@ref;
        request.ContentType = "application/json";
        string[] splitted = request.Reference.Split('/');
        // BodyComponent component = _components.Where(x => x.Name == splitted.Last()).FirstOrDefault();
        return request;
    }
    
    
}