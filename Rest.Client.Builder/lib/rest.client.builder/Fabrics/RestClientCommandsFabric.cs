using System.Text;
using Microsoft.Extensions.Primitives;

namespace rest.client.builder.Fabrics;

internal static class RestClientCommandsFabric
{
    internal static StringBuilder AppendNewLine(this StringBuilder sb)
        => sb.AppendLine();

    internal static StringBuilder AppendUrl(this StringBuilder sb, string url)
        => sb.Append($"@url={url}");

    internal static StringBuilder AppendNewRequest(this StringBuilder sb)
        => sb.Append("###");
    
    internal static StringBuilder AppendGetMethod(this StringBuilder sb)
        => sb.Append("GET {{url}}");

    internal static StringBuilder AppendParameter(this StringBuilder sb, string parameter)
        => sb.Append($"@{parameter}");

    internal static StringBuilder AppendText(this StringBuilder sb, string text)
        => sb.Append(text);
}