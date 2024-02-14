namespace rest.client.builder.Models;

internal sealed class PostRequest
{
    public string Path { get; set; }
    public string Reference { get; set; }
    public string ContentType { get; set; }
}