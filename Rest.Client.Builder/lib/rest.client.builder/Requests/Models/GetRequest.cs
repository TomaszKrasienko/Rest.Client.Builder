namespace rest.client.builder.Requests.Models;

internal sealed class GetRequest
{
    public string Path { get; set; }
    public Dictionary<string, string> Parameters { get; set; } 
}