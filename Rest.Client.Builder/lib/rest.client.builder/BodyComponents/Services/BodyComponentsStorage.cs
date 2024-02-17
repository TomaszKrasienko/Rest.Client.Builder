using rest.client.builder.BodyComponents.Models;
using rest.client.builder.BodyComponents.PropertyStrategy.Abstractions;
using rest.client.builder.BodyComponents.Services.Abstractions;
using rest.client.builder.OpenApi.Models;

namespace rest.client.builder.BodyComponents.Services;

internal sealed class BodyComponentsStorage(IEnumerable<IBodyComponentPropertyMapperStrategy> propertyMapperStrategies)
    : IBodyComponentsStorage
{
    private List<BodyComponent> _components = new List<BodyComponent>();

    public void Load(OpenApiDocument openApiDoc)
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
        
        LoadReferenceAsComponents();
    }
    
    private Dictionary<string, BodyComponentProperty> MapProperties(Dictionary<string, ComponentPropertiesOpenApiDocument> openApiProperties)
    {
        Dictionary<string, BodyComponentProperty> properties = new Dictionary<string, BodyComponentProperty>();
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

    private void LoadReferenceAsComponents()
    {
        foreach (var component in _components)
        {
            foreach (var property in component.Properties)
            {
                if (property.Value.Reference is not null)
                {
                    var typeName = property.Value.Reference.Split('/').Last();
                    var referencedType = _components.FirstOrDefault(x => x.Name == typeName);
                    property.Value.Component = referencedType;
                }
            }
        }
    }

    public BodyComponent GetByName(string name)
        => _components.FirstOrDefault(x => x.Name == name);
}

