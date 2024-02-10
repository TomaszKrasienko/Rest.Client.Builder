using System.Text;
using rest.client.builder.Const;

namespace rest.client.builder.Extensions;

internal static class FileContentBuilderExtensions
{
    internal static StringBuilder AddAddressVariable(this StringBuilder fileContent, string address,
        bool newLine = true)
        => newLine
            ? fileContent.AppendLine($"{RestClientFileKeyWords.AddressVariable}={address}")
            : fileContent.Append($"{RestClientFileKeyWords.AddressVariable}={address}");

    internal static StringBuilder AddNewLine(this StringBuilder fileContent)
        => fileContent.AppendLine();

    internal static StringBuilder AddControllerHeading(this StringBuilder fileContent, string controllerName)
        => fileContent.AppendLine($"# {controllerName}");
    
    
}