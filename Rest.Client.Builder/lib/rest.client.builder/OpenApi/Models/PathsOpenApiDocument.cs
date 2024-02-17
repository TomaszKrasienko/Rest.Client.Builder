using System.Text.Json.Serialization;

namespace rest.client.builder.OpenApi.Models;

internal sealed record PathsOpenApiDocument
{
    [JsonPropertyName("get")]
    public GetRequestOpenApiDocument GetRequest { get; init; }
    
    [JsonPropertyName("post")]
    public PostDoc PostRequest { get; init; }
}