using System.Text;
using rest.client.builder.File.Builders.Abstractions;
using rest.client.builder.File.Factories;

namespace rest.client.builder.File.Builders;

internal sealed class ParametersBuilder : IParametersBuilder
{
    private Dictionary<string, string> _parameters;
    
    public void SetParameters(Dictionary<string, string> parameters)
        => _parameters = parameters;

    public bool IsParametersExists()
        => _parameters is not null && _parameters.Any();  

    public string GetAsVariable()
    {
        if (_parameters is not null)
        {
            StringBuilder paramsBuilder = new StringBuilder();
            foreach (var parameter in _parameters)
            {
                paramsBuilder
                    .AppendNewLine()
                    .AppendNewRequest()
                    .AppendNewLine()
                    .AppendParameter(parameter.Key)
                    .AppendNewLine();
            }

            return paramsBuilder.ToString();
        }
        return string.Empty;
    }

    public bool IsQueryParameters()
        => _parameters is not null &&  _parameters.Any(x => x.Value == "query");

    public string GetAsQueryParameters()
    {
        var queryParams = _parameters?
            .Where(x => x.Value == "query")
            .Select(x => x.Key)
            .ToList();
        if (queryParams is null)
        {
            return string.Empty;
        }

        return GetQueryParameters(queryParams);
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
}