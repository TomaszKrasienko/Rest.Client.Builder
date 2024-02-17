using System.Text.Json.Serialization;

namespace rest.client.builder.OpenApi.Models;

internal sealed record ContentOpenApiDocument
{
    [JsonPropertyName("application/json")]
    public ApplicationJsonOpenApiDocument ApplicationJson { get; init; }
}