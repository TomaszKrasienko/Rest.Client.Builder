namespace rest.client.builder.BodyComponents.Models;

internal sealed class BodyComponentProperty
{
    public string Type { get; set; }
    public string Reference { get; set; }
    public BodyComponent Component { get; set; }
}