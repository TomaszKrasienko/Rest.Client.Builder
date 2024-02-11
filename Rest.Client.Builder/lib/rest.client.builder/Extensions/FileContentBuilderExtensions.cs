using System.Text;
using rest.client.builder.Const;

namespace rest.client.builder.Extensions;

internal static class FileContentBuilderExtensions
{
    internal static StringBuilder AddLine(this StringBuilder fileContent, string line)
        => fileContent.AppendLine(line);
    
    internal static StringBuilder AddAddressVariable(this StringBuilder fileContent, string address,
        bool newLine = true)
        => newLine
            ? fileContent.AppendLine($"{RestClientFileKeyWords.AddressVariable}={address}")
            : fileContent.Append($"{RestClientFileKeyWords.AddressVariable}={address}");

    internal static StringBuilder AddNewLine(this StringBuilder fileContent)
        => fileContent.AppendLine();

    internal static StringBuilder AddControllerHeading(this StringBuilder fileContent, string controllerName)
        => fileContent.AppendLine($"# {controllerName}");

    internal static StringBuilder AddNewRequestSign(this StringBuilder fileContent)
        => fileContent.AppendLine(RestClientFileKeyWords.NewRequestSign);

    internal static StringBuilder AddRequestMethodWithUrl(this StringBuilder fileContent,
        string method, string controllerRouting, string methodRouting, bool newLine = true)
    {
        fileContent
            .Append(method)
            .Append(' ')
            .Append(RestClientFileKeyWords.AddressVariableInMethod)
            .Append('/')
            .Append(controllerRouting);
        if (!string.IsNullOrWhiteSpace(methodRouting))
        {
            fileContent
                .Append('/')
                .Append(methodRouting);
        }
        if (newLine)
        {
            fileContent.AppendLine();
            return fileContent;
        }
        return fileContent;
    }
}