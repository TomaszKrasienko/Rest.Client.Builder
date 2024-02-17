using System.Text.Json.Serialization;

namespace rest.client.builder.OpenApi.Models;

internal sealed record SchemaOpenApiDocument
{      
    [JsonPropertyName("$ref")]
    public string Reference { get; init; }
}