using System.Text.Json.Serialization;

namespace rest.client.builder.OpenApi.Models;

internal sealed record OpenApiDocument
{
    [JsonPropertyName("paths")]
    public Dictionary<string, PathsOpenApiDocument> RequestPaths { get; init; }
    
    [JsonPropertyName("components")]
    public ComponentsOpenApiDocument Components { get; init; } 
}