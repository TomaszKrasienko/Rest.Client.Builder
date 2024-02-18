using Microsoft.AspNetCore.Builder.Extensions;
using rest.client.builder.OpenApi.Models;
using rest.client.builder.Requests.Models;

namespace rest.client.builder.Requests.Mappers;

internal static class RequestMappers
{
    internal static GetRequest AsGetRequest(this GetOpenApiDocument doc, string path)
        => new GetRequest()
        {
            Path = path,
            Parameters = doc.Parameters?.AsGetRequestParameters()
        };
    
    internal static DeleteRequest AsDeleteRequest(this DeleteOpenApiDocument doc, string path)
        => new DeleteRequest()
        {
            Path = path,
            Parameters = doc.Parameters?.AsGetRequestParameters()
        };

    private static Dictionary<string, string> AsGetRequestParameters(this List<ParametersOpenApiDocument> parameters)
        => parameters
            .ToDictionary(x => x.Name, y => y.In);

    internal static PostRequest AsPostRequest(this PostOpenApiDocument doc, string path)
        => new PostRequest()
        {
            Path = path,
            Parameters = doc.Parameters?.AsGetRequestParameters(),
            Reference = doc.RequestBody.Content.ApplicationJson.Schema.Reference,
            ContentType = "application/json"
        };
    
    internal static PatchRequest AsPatchRequest(this PatchOpenApiDocument doc, string path)
        => new PatchRequest()
        {
            Path = path,
            Parameters = doc.Parameters?.AsGetRequestParameters(),
            Reference = doc.RequestBody?.Content?.ApplicationJson?.Schema?.Reference,
            ContentType = "application/json"
        };
    
    internal static PutRequest AsPutRequest(this PutOpenApiDocument doc, string path)
        => new PutRequest()
        {
            Path = path,
            Parameters = doc.Parameters?.AsGetRequestParameters(),
            Reference = doc.RequestBody?.Content?.ApplicationJson?.Schema?.Reference,
            ContentType = "application/json"
        };

}