using System.Reflection;
using rest.client.builder.Searchers.Abstractions;

namespace rest.client.builder.Searchers;

internal sealed class AssembliesSearcher : IAssembliesSearcher
{
    public List<Assembly> GetAllAssemblies()
        => AppDomain
            .CurrentDomain
            .GetAssemblies()
            .Where(x => x.FullName != Assembly.GetAssembly(typeof(IAssembliesSearcher)).FullName)
            .ToList();
}