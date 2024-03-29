using System.Text.Json.Serialization;

namespace rest.client.builder.OpenApi.Models;

internal sealed record DeleteOpenApiDocument
{
    [JsonPropertyName("tags")]
    public List<string> Tags { get; init; }

    [JsonPropertyName("parameters")]
    public List<ParametersOpenApiDocument> Parameters { get; init; }
}