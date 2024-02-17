using System.Text;
using System.Text.Json;
using rest.client.builder.BodyComponents.Models;
using rest.client.builder.File.Builders.Abstractions;
using rest.client.builder.File.Factories;
using rest.client.builder.Requests.Models;

namespace rest.client.builder.File.Builders;

internal sealed class BodyComponentFileBuilder : IBodyComponentFileBuilder
{
    public string Build(BodyComponent bodyComponent)
    {
        string test = GetAllPropertiesWithKeys(bodyComponent);
        object json = JsonSerializer.Deserialize<object>(test);
        return JsonSerializer.Serialize(json, new JsonSerializerOptions { WriteIndented = true });
    }

    private string GetAllPropertiesWithKeys(BodyComponent component)
    {
        List<string> lines = new List<string>();
        foreach (var property in component.Properties)
        {
            if (property.Value.Component is not null)
            {
                lines.Add($"\"{property.Key}\":{GetAllPropertiesWithKeys(property.Value.Component)}");
            }
            else
            {
                lines.Add($"\"{property.Key}\":{GetDefaultTypeValue(property.Value.Type)}");
            }
        }

        StringBuilder sb = new StringBuilder();
        sb.AppendJsonBeginning()
            .AppendNewLine()
            .AppendText(string.Join(",\n", lines.ToArray()))
            .AppendNewLine()
            .AppendJsonEnd();
        return sb.ToString();
    } 

    private string GetDefaultTypeValue(string typeName)
    {
        if (typeName == "int")
        {
            return "1";
        }

        if (typeName == "Guid")
        {
            return "\"" + Guid.NewGuid().ToString() + "\"";
        }

        if (typeName == "string")
        {
            return "\"test\"";
        }
        
        return string.Empty;
    }
}