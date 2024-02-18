using System.Text.Json.Serialization;
using rest.client.builder.Requests.Models;

namespace rest.client.builder.OpenApi.Models;

internal sealed record GetOpenApiDocument
{
    [JsonPropertyName("tags")]
    public List<string> Tags { get; init; }

    [JsonPropertyName("parameters")]
    public List<ParametersOpenApiDocument> Parameters { get; init; }
    
}