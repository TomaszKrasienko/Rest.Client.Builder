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
        string controllerName = controllerType.Name;
        fileContent.AppendLine();
        fileContent.AppendLine($"# {controllerName}");
        fileContent.AppendLine();
        var attributes = (RouteAttribute)controllerType
            .GetCustomAttributes(_routeAttributeType, false)
            .FirstOrDefault();
        var controllerRouting = GetRoutingFromController(attributes, controllerName);
        HandleGetMethods(controllerType, fileContent, controllerRouting);

    }

    private void HandleGetMethods(Type controllerType, StringBuilder fileContent, string controllerRouting)
    {
        var methods = GetMethodsByAttribute(controllerType, _getRouteAttributeType);
        foreach (var method in methods)
        {
            var attribute = (HttpGetAttribute)method
                .GetCustomAttributes(_getRouteAttributeType, false)
                .FirstOrDefault();

            fileContent.AppendLine("###");
            fileContent.Append("GET ");
            fileContent.Append($"{{url}}/{controllerRouting}");
            if (attribute.Template is not null)
            {
                fileContent.Append("/");
                string value = attribute.Template;
                if (value.Any(x => x == ':'))
                {
                    value = $"{value.Substring(0, value.IndexOf(':'))}}}";
                }
                fileContent.Append(value);
            }

            fileContent.AppendLine();
            var tmp = fileContent.ToString();
        }
        
        
    }

    private IEnumerable<MethodInfo> GetMethodsByAttribute(Type controllerType, Type attributeType)
        => controllerType
            .GetMethods()
            .Where(x => x.GetCustomAttributes(attributeType, false).Length != 0);

    private string GetRoutingFromController(RouteAttribute attribute, string controllerName)
    {
        string routeFromController = controllerName.Replace("Controller", "");
        string template = attribute.Template;
        return template.Replace("[controller]", routeFromController);
    }
}