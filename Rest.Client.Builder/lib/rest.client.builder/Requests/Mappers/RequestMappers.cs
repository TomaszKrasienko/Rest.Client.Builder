using Microsoft.AspNetCore.Builder.Extensions;
using rest.client.builder.OpenApi.Models;
using rest.client.builder.Requests.Models;

namespace rest.client.builder.Requests.Mappers;

internal static class RequestMappers
{
    internal static GetRequest AsGetRequest(this GetDoc doc, string path)
        => new GetRequest()
        {
            Path = path,
            Parameters = doc.Parameters?.AsGetRequestParameters()
        };

    private static Dictionary<string, string> AsGetRequestParameters(this List<ParametersDoc> parameters)
        => parameters
            .ToDictionary(x => x.Name, y => y.In);

    internal static PostRequest AsPostRequest(this PostDoc doc, string path)
        => new PostRequest()
        {
            Path = path,
            Reference = doc.RequestBody.Content.ApplicationJson.Schema.@ref,
            ContentType = "application/json"
        };

}