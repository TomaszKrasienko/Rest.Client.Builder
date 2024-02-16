namespace rest.client.builder.BodyComponents.Models;

internal sealed class BodyComponent
{
    internal string Name { get; set; }
    internal string Type { get; set; }
    internal BodyComponent Component { get; set; }
    internal Dictionary<string, object> Properties { get; set; }
}