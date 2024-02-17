namespace rest.client.builder.Requests.Models;

internal sealed class GetRequest
{
    internal string Path { get; set; }
    internal Dictionary<string, string> Parameters { get; set; } 
}