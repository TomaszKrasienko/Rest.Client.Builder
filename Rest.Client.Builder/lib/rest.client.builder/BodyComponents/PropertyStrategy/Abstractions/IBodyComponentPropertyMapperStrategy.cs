using rest.client.builder.BodyComponents.Models;
using rest.client.builder.OpenApi.Models;

namespace rest.client.builder.BodyComponents.PropertyStrategy.Abstractions;

internal interface IBodyComponentPropertyMapperStrategy
{
    bool CanBeApplied(ComponentPropertiesDoc componentPropertiesDoc);
    KeyValuePair<string, BodyComponentProperty> Get(KeyValuePair<string, ComponentPropertiesDoc> openApiProperty);
}