using System.Reflection;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using rest.client.builder.Const;

namespace rest.client.builder.Builders;

internal sealed class GetMethodBuilder : IGetMethodBuilder
{
    private readonly Type _getRouteAttributeType = typeof(HttpGetAttribute);
    private readonly string _controllerRoute;
    private readonly MethodInfo _methodInfo;
    private readonly List<string> _methodParameters;

    private GetMethodBuilder(string controllerRoute, MethodInfo methodInfo)
    {
        _controllerRoute = controllerRoute;
        _methodInfo = methodInfo;
        _methodParameters = new List<string>();
    }

    internal static GetMethodBuilder Create(string controllerRoute, MethodInfo methodInfo)
        => new GetMethodBuilder(controllerRoute, methodInfo);
    

    public string BuildRoute()
    {
        StringBuilder methodStringBuilder = new StringBuilder();
        string methodRoute = GetMethodRoute();
        methodStringBuilder
            .AppendLine(RestClientFileKeyWords.NewRequestSign)
            .Append(RestClientFileKeyWords.GetRequestSign)
            .Append(' ')
            .Append(RestClientFileKeyWords.AddressVariableInMethod)
            .Append('/')
            .Append(_controllerRoute)
            .Append('/')
            .Append(methodRoute);
        return methodStringBuilder.ToString();
    }

    private string GetMethodRoute()
    {
        var attribute = (HttpGetAttribute)_methodInfo
            .GetCustomAttributes(_getRouteAttributeType, false)
            .FirstOrDefault();
        if (attribute?.Template is null || string.IsNullOrWhiteSpace(attribute.Template))
        {
            return string.Empty;
        }

        string methodRoute = attribute.Template;
        
        var methodParams = _methodInfo.GetParameters();
        if (methodParams.Length == 0)
        {
            return methodRoute.ToString();
        }

        Dictionary<string, string> queryParams = new Dictionary<string, string>();
        foreach (var parameter in methodParams)
        {
            var parameterName = $"{_methodInfo.Name}_{parameter.Name}";
            _methodParameters.Add(parameterName);
            if (!IsParameterFromRoute(parameter, attribute.Template))
            {
                queryParams.Add(parameter.Name, $"{{{parameterName}}}");
            }
            else
            {
                methodRoute = methodRoute.Replace($"{{{parameter.Name}}}", $"{{{parameterName}}}");
            }
        }

        if (!queryParams.Any())
        {
            return methodRoute;
        }
        //Building query params - for refactor
        StringBuilder methodRouteBuilder = new StringBuilder();
        methodRouteBuilder.Append(methodRoute);
        int count = 0;
        foreach (var param in queryParams)
        {
            if (count == 0)
            {
                methodRouteBuilder.Append($"?{param.Key}={param.Value}");
            }
            else
            {
                methodRouteBuilder.Append($"&{param.Key}={param.Value}");
            }
        }
        return methodRouteBuilder.ToString();
    }

    private bool IsParameterFromRoute(ParameterInfo parameter, string template)
        => template.Contains($"{{{parameter.Name!}}}");
}