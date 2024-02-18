using System.Text.Json.Serialization;

namespace rest.client.builder.OpenApi.Models;

internal sealed record PathsOpenApiDocument
{
    [JsonPropertyName("get")]
    public GetOpenApiDocument GetRequest { get; init; }
    
    [JsonPropertyName("delete")]
    public DeleteOpenApiDocument DeleteRequest { get; init; }
    
    [JsonPropertyName("post")]
    public PostOpenApiDocument PostRequest { get; init; }
    
    [JsonPropertyName("patch")]
    public PatchOpenApiDocument PatchRequest { get; init; }
    
    [JsonPropertyName("put")]
    public PutOpenApiDocument PutRequest { get; init; }
}