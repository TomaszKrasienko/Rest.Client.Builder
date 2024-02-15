using System.Text;
using rest.client.builder.Builders.Abstractions;
using rest.client.builder.Fabrics;
using rest.client.builder.Models;

namespace rest.client.builder.Builders;

internal sealed class RestClientFileBuilder : IRestClientFileBuilder
{
    private StringBuilder _fileContentBuilder;

    public RestClientFileBuilder()
        => _fileContentBuilder = new StringBuilder();

    public void SetAddress(string address)
        => _fileContentBuilder
            .AppendUrl(address)
            .AppendNewLine()
            .AppendNewLine();

    public void SetGetRequest(GetRequest request)
    {
            var parameters = request.Parameters?.Keys?.ToList();
            //if null
            if (parameters is not null)
            {
                foreach (var parameter in parameters)
                {
                    _fileContentBuilder
                        .AppendNewLine()
                        .AppendParameter(parameter)
                        .AppendNewLine();
                }
            }

            var queryParams = request.Parameters?
                .Where(x => x.Value == "query")
                .Select(x => x.Key)
                .ToList();
            string queryParamsString = queryParams is not null ? GetQueryParameters(queryParams) : string.Empty;

            _fileContentBuilder
                .AppendNewRequest()
                .AppendNewLine()
                .AppendGetMethod()
                .AppendText($"{request.Path}")
                .AppendText(queryParamsString)
                .AppendNewLine();
    }
    
    private string GetQueryParameters(List<string> queryParameters)
    {
        if (queryParameters is null)
        {
            return string.Empty;
        }

        if (!queryParameters.Any())
        {
            return string.Empty;
        }

        StringBuilder sb = new StringBuilder();
        sb.Append($"?{queryParameters[0]}={{{queryParameters[0]}}}");

        if (queryParameters.Count > 1)
        {
            for (int i = 1; i < queryParameters.Count; i++)
            {
                sb.Append($"&{queryParameters[i]}={{{queryParameters[i]}}}");
            }
        }

        return sb.ToString();
    }

    public void SetPostRequest(PostRequest request)
    {
        _fileContentBuilder
            .AppendNewRequest()
            .
    }
    
    public string Build()
        => _fileContentBuilder.ToString();
}