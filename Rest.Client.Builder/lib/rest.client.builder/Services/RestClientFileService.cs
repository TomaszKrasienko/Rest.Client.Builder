using rest.client.builder.BodyComponents.Services.Abstractions;
using rest.client.builder.File.Abstractions;
using rest.client.builder.File.Builders.Abstractions;
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
        var openApiDocument = await _openApiClient.GetOpenApiDocumentation();
        _bodyComponentsStorage.Load(openApiDocument);
        _restClientFileBuilder.SetAddress("http://localhost:5226");
        foreach (var path in openApiDocument.RequestPaths)
        {
            if (path.Value.GetRequest is not null)
            {
                _restClientFileBuilder.SetGetRequest(path.Value.GetRequest.AsGetRequest(path.Key));
            }
            
            if (path.Value.DeleteRequest is not null)
            {
                _restClientFileBuilder.SetDeleteRequest(path.Value.DeleteRequest.AsDeleteRequest(path.Key));
            }

            if (path.Value.PostRequest is not null)
            {
                _restClientFileBuilder.SetPostRequest(path.Value.PostRequest.AsPostRequest(path.Key));
            }
            
            if (path.Value.PatchRequest is not null)
            {
                _restClientFileBuilder.SetPatchRequest(path.Value.PatchRequest.AsPatchRequest(path.Key));
            }
            
            if (path.Value.PutRequest is not null)
            {
                _restClientFileBuilder.SetPutRequest(path.Value.PutRequest.AsPutRequest(path.Key));
            }
        }
        string fileContent = _restClientFileBuilder.Build();
        _fileWriter.Write(fileContent);
    }
}