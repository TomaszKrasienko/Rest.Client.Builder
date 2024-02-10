using System.Text;

namespace rest.client.builder.Services.Abstractions;

internal interface IControllerHandler
{
    void HandleController(Type controllerType, StringBuilder fileContent);
}