using rest.client.builder.BodyComponents.Models;

namespace rest.client.builder.Requests.Models;

internal sealed class PostRequest
{
    public string Path { get; set; }
    public string Reference { get; set; }
    public string ContentType { get; set; }
    public BodyComponent Component { get; set; }
}