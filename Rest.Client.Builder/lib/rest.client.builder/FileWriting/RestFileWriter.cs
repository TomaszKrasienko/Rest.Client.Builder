using System.Reflection;
using rest.client.builder.FileWriting.Abstractions;

namespace rest.client.builder.FileWriting;

internal sealed class RestFileWriter : IFileWriter
{
    public void Write(string file)
    {
        var assemblyName = Assembly.GetEntryAssembly()?.GetName().Name;
        var fileName = $"{assemblyName}_rcb.rest";
        File.WriteAllText(fileName,file);
    }
}