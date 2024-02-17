using System.Text.Json.Serialization;

namespace rest.client.builder.OpenApi.Models;

internal sealed record ComponentPropertyItemOpenApiDocument
{
    [JsonPropertyName($"$ref")] 
    public string Reference { get; init; }
}