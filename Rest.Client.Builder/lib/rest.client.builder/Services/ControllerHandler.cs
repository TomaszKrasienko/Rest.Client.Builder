using System.Reflection;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using rest.client.builder.Services.Abstractions;

namespace rest.client.builder.Services;

internal sealed class ControllerHandler : IControllerHandler
{
    private readonly Type _routeAttributeType = typeof(RouteAttribute);
    private readonly Type _getRouteAttributeType = typeof(HttpGetAttribute);
    private readonly Type _postRouteAttributeType = typeof(HttpPostAttribute);
    
    public void HandleController(Type controllerType, StringBuilder fileContent)
    {
        fileContent.AppendLine();
        fileContent.AppendLine($"### {controllerType.Name}");
        var attributes = (RouteAttribute)controllerType
            .GetCustomAttributes(_routeAttributeType, false)
            .FirstOrDefault();
        GetRoutingFromController(attributes, controllerType);
        HandleGetMethods(controllerType, fileContent);

    }

    private void HandleGetMethods(Type controllerType, StringBuilder fileContent)
    {
        var methods = GetMethodsByAttribute(controllerType, _getRouteAttributeType);
        
    }

    private IEnumerable<MethodInfo> GetMethodsByAttribute(Type controllerType, Type attributeType)
        => controllerType
            .GetMethods()
            .Where(x => x.GetCustomAttributes(attributeType, false).Length != 0);

    private string GetRoutingFromController(RouteAttribute attribute, Type controllerType)
    {
        string name = controllerType.Name;
        string template = attribute.Template;
        return string.Empty;
    }
}