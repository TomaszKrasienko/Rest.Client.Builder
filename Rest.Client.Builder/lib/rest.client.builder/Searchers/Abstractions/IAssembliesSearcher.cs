using System.Reflection;

namespace rest.client.builder.Searchers.Abstractions;

internal interface IAssembliesSearcher
{
    List<Assembly> GetAllAssemblies();
}