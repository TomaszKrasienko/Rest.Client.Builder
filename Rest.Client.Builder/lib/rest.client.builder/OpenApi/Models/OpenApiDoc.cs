namespace rest.client.builder.OpenApi.Models;

public class OpenApiDoc
{
    public Dictionary<string, Paths> Paths { get; set; }
}

public class Paths
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
    public object RequestBody { get; set; }
    public object Responses { get; set; }
}

public class ParametersDoc
{
    public string Name { get; set; }
    public string In { get; set; }
    public string Style { get; set; }
    public object Schema { get; set; }
    public bool Required { get; set; }
}