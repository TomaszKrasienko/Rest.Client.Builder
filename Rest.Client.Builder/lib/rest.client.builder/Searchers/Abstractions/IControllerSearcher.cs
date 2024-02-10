using System.Reflection;

namespace rest.client.builder.Searchers.Abstractions;

internal interface IControllerSearcher
{
    List<Type> GetAllControllersFromAssemblies(List<Assembly> assemblies);
}