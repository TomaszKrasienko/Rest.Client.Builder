using System.Text.Json.Serialization;

namespace rest.client.builder.OpenApi.Models;

internal sealed record ComponentSchemaOpenApiDocument
{
    [JsonPropertyName("type")]
    public string Type { get; init; }
    
    [JsonPropertyName("properties")]
    public Dictionary<string, ComponentPropertiesOpenApiDocument> Properties { get; init; }
}