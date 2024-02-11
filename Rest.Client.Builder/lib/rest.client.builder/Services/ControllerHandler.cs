using System.Reflection;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using rest.client.builder.Const;
using rest.client.builder.Extensions;
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
        fileContent
            .AddControllerHeading(controllerName)
            .AddNewLine();

        var controllerRouting = GetControllerRouting(controllerType);
        HandleGetMethods(controllerType, fileContent, controllerRouting);
    }
    
    //Todo: after extends it possible to multiple attributes?
    private string GetControllerRouting(Type controllerType)
    {
        var attribute = (RouteAttribute)controllerType
            .GetCustomAttributes(_routeAttributeType, false)
            .FirstOrDefault();
        if (attribute is null)
        {
            return string.Empty;
        }
        
        string template = attribute.Template;
        if (template.Contains(RoutingKeyWords.ControllerRoutingTemplate))
        {
            string controllerNameRoute = controllerType.Name.Replace(RoutingKeyWords.ControllerSufix, string.Empty);
            template = template.Replace(RoutingKeyWords.ControllerRoutingTemplate, controllerNameRoute);
        }

        return template;
    }

    private void HandleGetMethods(Type controllerType, StringBuilder fileContent, string controllerRouting)
    {
        var methods = GetMethodsByAttribute(controllerType, _getRouteAttributeType);
        foreach (var method in methods)
        {
            StringBuilder methodAddress = new StringBuilder();
            methodAddress.AddNewRequestSign();
            var attribute = (HttpGetAttribute)method
                .GetCustomAttributes(_getRouteAttributeType, false)
                .FirstOrDefault();
            
            string methodRouting = string.Empty;
            if (attribute!.Template is not null)
            {
                string value = attribute.Template;
                if (value.Any(x => x == ':'))
                {
                    methodRouting = $"{value.Substring(0, value.IndexOf(':'))}}}";
                }
                else
                {
                    methodRouting = value;
                }
            }

            methodAddress
                .AddRequestMethodWithUrl(RestClientFileKeyWords.GetRequestSign, controllerRouting,
                    methodRouting);
            var methodTmp = methodAddress.ToString();
            fileContent.AddLine(methodAddress.ToString());
            var allTmp = fileContent.ToString();
        }
        var tmp = fileContent.ToString();
    }

    private IEnumerable<MethodInfo> GetMethodsByAttribute(Type controllerType, Type attributeType)
        => controllerType
            .GetMethods()
            .Where(x => x.GetCustomAttributes(attributeType, false).Length != 0);


}