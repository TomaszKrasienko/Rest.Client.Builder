using System.Reflection;
using rest.client.builder.File.Abstractions;

namespace rest.client.builder.File;

internal sealed class RestFileWriter : IFileWriter
{
    public void Write(string file)
    {
        var assemblyName = Assembly.GetEntryAssembly()?.GetName().Name;
        var fileName = $"{assemblyName}_rcb.rest";
        System.IO.File.WriteAllText(fileName,file);
    }
}