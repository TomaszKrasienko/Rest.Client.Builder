using System.Text;

namespace rest.client.builder.File.Factories;

internal static class RestClientCommandsFactory
{
    internal static StringBuilder AppendNewLine(this StringBuilder sb)
        => sb.AppendLine();

    internal static StringBuilder AppendUrl(this StringBuilder sb, string url)
        => sb.Append($"@url={url}");

    internal static StringBuilder AppendNewRequest(this StringBuilder sb)
        => sb.Append("###");
    
    internal static StringBuilder AppendGetMethod(this StringBuilder sb)
        => sb.Append("GET {{url}}");

    internal static StringBuilder AppendPostMethod(this StringBuilder sb)
        => sb.Append("POST {{url}}");
    
    internal static StringBuilder AppendPatchMethod(this StringBuilder sb)
        => sb.Append("PATCH {{url}}");
    
    internal static StringBuilder AppendDeleteMethod(this StringBuilder sb)
        => sb.Append("DELETE {{url}}");
    
    internal static StringBuilder AppendPutMethod(this StringBuilder sb)
        => sb.Append("PUT {{url}}");

    internal static StringBuilder AppendParameter(this StringBuilder sb, string parameter)
        => sb.Append($"@{parameter}=");

    internal static StringBuilder AppendText(this StringBuilder sb, string text)
        => sb.Append(text);

    internal static StringBuilder AppendJsonBeginning(this StringBuilder sb)
        => sb.Append("{");
    
    internal static StringBuilder AppendJsonEnd(this StringBuilder sb)
        => sb.Append("}");

    internal static StringBuilder AppendTextInQuotes(this StringBuilder sb, string text)
        => sb.Append($"\"{text}\"");

    internal static StringBuilder AppendContentType(this StringBuilder sb, string text)
        => sb.Append($"Content-Type: {text}");
}