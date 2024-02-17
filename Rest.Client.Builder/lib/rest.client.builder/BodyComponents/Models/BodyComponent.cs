namespace rest.client.builder.BodyComponents.Models;

internal sealed class BodyComponent
{
    internal string Name { get; set; }
    internal string Type { get; set; }
    internal Dictionary<string, BodyComponentProperty> Properties { get; set; }
}