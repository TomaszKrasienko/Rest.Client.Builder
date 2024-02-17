using System.Text.Json.Serialization;

namespace rest.client.builder.OpenApi.Models;

internal sealed record RequestBodyOpenApiDocument
{
    [JsonPropertyName("content")]
    public ContentOpenApiDocument Content { get; init; }
}