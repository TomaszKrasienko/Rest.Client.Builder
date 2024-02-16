using rest.client.builder.OpenApi.Models;

namespace rest.client.builder.BodyComponents.PropertyStrategy.Abstractions;

public interface IBodyComponentPropertyMapperStrategy
{
    bool CanBeApplied(ComponentPropertiesDoc componentPropertiesDoc);
    KeyValuePair<string, object> Get(KeyValuePair<string, ComponentPropertiesDoc> openApiProperty);
}