using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;

namespace rest.client.builder.OpenApi.Models;

public class OpenApiDoc
{
    public Dictionary<string, PathsDoc> Paths { get; set; }
    public ComponentsDoc Components { get; set; } 
}

public class ComponentsDoc
{
    public Dictionary<string, ComponentSchemaDoc> Schemas { get; set; }
}

public class ComponentSchemaDoc
{
    public string Type { get; set; }
    public Dictionary<string, ComponentPropertiesDoc> Properties { get; set; }
}

public class ComponentPropertiesDoc
{
    public string Type { get; set; }
    public bool Nullable { get; set; }
    [JsonPropertyName($"$ref")] public string Ref { get; set; }
    public ComponentPropertyItemDoc Items { get; set; }
}

public class ComponentPropertyItemDoc
{
    [JsonPropertyName($"$ref")] public string Ref { get; set; }
}

public class PathsDoc
{
    public GetDoc Get { get; set; }
    public PostDoc Post { get; set; }
}

public class GetDoc
{
    public List<string> Tags { get; set; }
    public List<ParametersDoc> Parameters { get; set; }
    public object Responses { get; set; }
}

public class PostDoc
{
    public List<string> Tags { get; set; }
    public RequestBodyDoc RequestBody { get; set; }
    public object Responses { get; set; }
}

public class RequestBodyDoc
{
    public ContentDoc Content { get; set; }
}

public class ContentDoc
{
    [JsonPropertyName("application/json")]
    public ApplicationJson ApplicationJson { get; set; }
}

public class ApplicationJson
{
    public SchemaDoc Schema { get; set; }
}

public class SchemaDoc
{      
    [JsonPropertyName("$ref")]
    public string @ref { get; set; }
}

public class ParametersDoc
{
    public string Name { get; set; }
    public string In { get; set; }
    public string Style { get; set; }
    public object Schema { get; set; }
    public bool Required { get; set; }
}
