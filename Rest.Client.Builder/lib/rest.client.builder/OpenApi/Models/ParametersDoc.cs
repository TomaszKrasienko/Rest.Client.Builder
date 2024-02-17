using System.Text.Json.Serialization;

namespace rest.client.builder.OpenApi.Models;

internal sealed record ParametersOpenApiDocument
{
    [JsonPropertyName("name")]
    public string Name { get; init; }
    
    [JsonPropertyName("in")]
    public string In { get; init; }
    
    [JsonPropertyName("style")]
    public string Style { get; init; }
    
    [JsonPropertyName("schema")]
    public object Schema { get; init; }
    
    [JsonPropertyName("required")]
    public bool Required { get; init; }
}