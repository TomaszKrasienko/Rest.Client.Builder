using System.Text.Json.Serialization;

namespace rest.client.builder.OpenApi.Models;

internal sealed record  ApplicationJsonOpenApiDocument
{
    [JsonPropertyName("schema")]
    public SchemaOpenApiDocument Schema { get; init; }
}