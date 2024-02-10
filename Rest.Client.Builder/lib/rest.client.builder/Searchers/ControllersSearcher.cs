using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using rest.client.builder.Searchers.Abstractions;

namespace rest.client.builder.Searchers;

internal sealed class ControllersSearcher : IControllerSearcher
{
    public List<Type> GetAllControllersFromAssemblies(List<Assembly> assemblies)
    {
        var tmp = assemblies.SelectMany(x => x.GetTypes())
            .Where(x => typeof(ControllerBase).IsAssignableFrom(x));
        return tmp.ToList();
    }
}