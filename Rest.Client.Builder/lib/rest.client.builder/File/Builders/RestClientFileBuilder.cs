using System.Text;
using rest.client.builder.BodyComponents.Services.Abstractions;
using rest.client.builder.File.Builders.Abstractions;
using rest.client.builder.File.Factories;
using rest.client.builder.Requests.Models;

namespace rest.client.builder.File.Builders;

internal sealed class RestClientFileBuilder(
    IBodyComponentsStorage bodyComponentsStorage,
    IBodyComponentFileBuilder bodyComponentFileBuilder) : IRestClientFileBuilder
{
    private readonly StringBuilder _fileContentBuilder = new();

    public void SetAddress(string address)
        => _fileContentBuilder
            .AppendUrl(address)
            .AppendNewLine()
            .AppendNewLine();

    public void SetGetRequest(GetRequest request)
    {
        var requestName = request.Path.Split("/").LastOrDefault() ?? string.Empty;
        var parameters_ = request.Parameters?.ToDictionary(x 
            => $"{x}-{requestName}", y => y.Value);
            // var parameters = request.Parameters?.Keys?.ToList();
            //if null
        
            if (parameters_ is not null)
            {
                foreach (var parameter in parameters_)
                {
                    _fileContentBuilder
                        .AppendNewLine()
                        .AppendNewRequest()
                        .AppendNewLine()
                        .AppendParameter(parameter.Key)
                        .AppendNewLine();
                }
            }

            var queryParams = parameters_?
                .Where(x => x.Value == "query")
                .Select(x => x.Key)
                .ToList();
            string queryParamsString = queryParams is not null ? GetQueryParameters(queryParams) : string.Empty;

            var path = request.Path.Replace("{", "{{").Replace("}", "}}");
            
            _fileContentBuilder
                .AppendNewLine()
                .AppendNewRequest()
                .AppendNewLine()
                .AppendGetMethod()
                .AppendText($"{request.Path.Replace("{", "{{").Replace("}", "}}")}")
                .AppendText(queryParamsString)
                .AppendNewLine();
    }

    public void SetPostRequest(PostRequest request)
    {
        var requestName = request.Path.Split("/").LastOrDefault() ?? string.Empty;
        var parameters = request.Parameters?.Keys?.ToList();
        AppendParametersDefinition(parameters?.Select(x => $"{x}-{requestName}").ToList());

        var queryParams = request.Parameters?
            .Where(x => x.Value == "query")
            .Select(x => x.Key)
            .ToList();
        string queryParamsString = queryParams is not null ? GetQueryParameters(queryParams?.Select(x => $"{x}-{requestName}").ToList()) : string.Empty;
        
        _fileContentBuilder
            .AppendNewLine()
            .AppendNewRequest()
            .AppendNewLine()
            .AppendPostMethod()
            .AppendText(request.Path)
            .AppendText(queryParamsString)
            .AppendNewLine()
            .AppendContentType(request.ContentType)
            .AppendNewLine()
            .AppendNewLine();

        if (!string.IsNullOrWhiteSpace(request.Reference))
        {
            var bodyComponentType = request.Reference.Split('/').Last();
            var component = bodyComponentsStorage.GetByName(bodyComponentType);
            _fileContentBuilder
                .AppendText(bodyComponentFileBuilder.Build(component))
                .AppendNewLine();
        }
    }

    private void AppendParametersDefinition(List<string> parameters)
    {
        if (parameters is not null)
        {
            foreach (var parameter in parameters)
            {
                _fileContentBuilder
                    .AppendNewLine()
                    .AppendNewRequest()
                    .AppendNewLine()
                    .AppendParameter(parameter)
                    .AppendNewLine();
            }
        }
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
        sb.Append($"?{queryParameters[0]}={{{{{queryParameters[0]}}}}}");

        if (queryParameters.Count > 1)
        {
            for (int i = 1; i < queryParameters.Count; i++)
            {
                sb.Append($"&{queryParameters[i]}={{{queryParameters[i]}}}");
            }
        }

        return sb.ToString();
    }
    
    public string Build()
        => _fileContentBuilder.ToString();
}

internal record ParameterData(string Source, string OriginalName);