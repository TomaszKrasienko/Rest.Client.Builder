using System.Text.Json.Serialization;

namespace rest.client.builder.OpenApi.Models;

internal sealed record ComponentsOpenApiDocument
{
    [JsonPropertyName("schemas")]
    public Dictionary<string, ComponentSchemaOpenApiDocument> Schemas { get; init; }
}