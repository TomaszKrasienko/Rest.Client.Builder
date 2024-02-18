namespace rest.client.builder.Requests.Models;

internal sealed class DeleteRequest
{
    internal string Path { get; set; }
    internal Dictionary<string, string> Parameters { get; set; } 
}