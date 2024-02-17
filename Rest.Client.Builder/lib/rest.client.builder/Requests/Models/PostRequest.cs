using rest.client.builder.BodyComponents.Models;

namespace rest.client.builder.Requests.Models;

internal sealed class PostRequest
{
    internal string Path { get; set; }
    internal Dictionary<string, string> Parameters { get; set; }
    internal string Reference { get; set; }
    internal string ContentType { get; set; }
    internal BodyComponent Component { get; set; }
}