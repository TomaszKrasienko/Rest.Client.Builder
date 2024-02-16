using rest.client.builder.BodyComponents.Models;
using rest.client.builder.BodyComponents.PropertyStrategy.Abstractions;
using rest.client.builder.BodyComponents.Services.Abstractions;
using rest.client.builder.OpenApi.Models;

namespace rest.client.builder.BodyComponents.Services;

internal sealed class BodyComponentsStorage(IEnumerable<IBodyComponentPropertyMapperStrategy> propertyMapperStrategies)
    : IBodyComponentsStorage
{
    private List<BodyComponent> _components = new List<BodyComponent>();

    public void Load(OpenApiDoc openApiDoc)
    {
        var openApiComponents = openApiDoc.Components?.Schemas;
        if (openApiComponents is null)
        {
            return;
        }
        
        foreach (var openApiComponent in openApiComponents)
        {
            _components.Add(new BodyComponent()
            {
                Name = openApiComponent.Key,
                Type = openApiComponent.Value.Type,
                Properties = MapProperties(openApiComponent.Value.Properties)
            });
        }
    }
    
    private Dictionary<string, object> MapProperties(Dictionary<string, ComponentPropertiesDoc> openApiProperties)
    {
        Dictionary<string, object> properties = new Dictionary<string, object>();
        foreach (var openApiProperty in openApiProperties)
        {
            var propertyMapperStrategy = propertyMapperStrategies.SingleOrDefault(x
                => x.CanBeApplied(openApiProperty.Value));
            if (propertyMapperStrategy is null)
            {
                continue;
            }
            var property = propertyMapperStrategy.Get(openApiProperty);
            properties.Add(property.Key, property.Value);
        }
        return properties;
    }
    
    
}