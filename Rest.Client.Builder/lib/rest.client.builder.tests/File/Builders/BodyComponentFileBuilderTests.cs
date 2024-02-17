using rest.client.builder.BodyComponents.Models;
using rest.client.builder.File.Builders;
using rest.client.builder.File.Builders.Abstractions;
using Xunit;

namespace rest.client.builder.tests.File.Builders;

public sealed class BodyComponentFileBuilderTests
{
    private string Act(BodyComponent bodyComponent) => _bodyComponentFileBuilder.Build(bodyComponent);
    
    [Fact]
    public void Set_ForGivenStrictTypePropertiesInBodyComponentAfterBuild_ShouldReturnStringWithJsonFormatting()
    {
        //arrange
        var properties = new Dictionary<string, BodyComponentProperty>()
        {
            ["property_key_test_1"] = new BodyComponentProperty()
            {
                Type = "string"
            },
            ["property_key_test_2"] = new BodyComponentProperty()
            {
                Type = "int"
            }
        };
        BodyComponent bodyComponent = new BodyComponent()
        {
            Name = "test_body_component_name",
            Properties = properties
        };
        
        //act
        string result = Act(bodyComponent);
        
        //assert
    }
    
    #region arrange
    private readonly IBodyComponentFileBuilder _bodyComponentFileBuilder;

    public BodyComponentFileBuilderTests()
    {
        _bodyComponentFileBuilder = new BodyComponentFileBuilder();
    }
    #endregion
}