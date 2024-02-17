using System.Text.Json.Serialization;

namespace rest.client.builder.OpenApi.Models;

internal sealed record ComponentPropertiesOpenApiDocument
{
    [JsonPropertyName("type")]
    public string Type { get; init; }
    
    [JsonPropertyName("nullable")]
    
    public bool Nullable { get; init; }
    
    [JsonPropertyName($"$ref")] 
    public string Reference { get; init; }
    
    [JsonPropertyName("items")]
    public ComponentPropertyItemOpenApiDocument Items { get; init; }
}