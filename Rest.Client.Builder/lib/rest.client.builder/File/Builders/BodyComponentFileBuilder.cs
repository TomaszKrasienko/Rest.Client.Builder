using System.Text;
using rest.client.builder.BodyComponents.Models;
using rest.client.builder.File.Builders.Abstractions;
using rest.client.builder.File.Factories;

namespace rest.client.builder.File.Builders;

internal sealed class BodyComponentFileBuilder : IBodyComponentFileBuilder
{
    public string Build(BodyComponent bodyComponent)
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendJsonBeginning()
            .AppendNewLine();

        foreach (var property in bodyComponent.Properties)
        {
            sb.AppendTextInQuotes(property.Key)
                .AppendText(":")
                .AppendText(GetDefaultTypeValue(property.Value.Type))
                .AppendText(",")
                .AppendNewLine();
        }

        sb.AppendJsonEnd();
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