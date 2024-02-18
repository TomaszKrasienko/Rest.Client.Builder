using System.Text;
using rest.client.builder.BodyComponents.Services.Abstractions;
using rest.client.builder.File.Builders.Abstractions;
using rest.client.builder.File.Factories;
using rest.client.builder.Requests.Models;

namespace rest.client.builder.File.Builders;

internal sealed class RestClientFileBuilder(
    IBodyComponentsStorage bodyComponentsStorage,
    IBodyComponentFileBuilder bodyComponentFileBuilder,
    IParametersBuilder parametersBuilder) : IRestClientFileBuilder
{
    private readonly StringBuilder _fileContentBuilder = new();

    public void SetAddress(string address)
        => _fileContentBuilder
            .AppendUrl(address)
            .AppendNewLine()
            .AppendNewLine();

    public void SetGetRequest(GetRequest request)
    {
        parametersBuilder.SetParameters(request.Parameters);
        if (parametersBuilder.IsParametersExists())
        {
            _fileContentBuilder.AppendText(parametersBuilder.GetAsVariable());
        }
        
        var path = request.Path.Replace("{", "{{").Replace("}", "}}");

        if (parametersBuilder.IsQueryParameters())
        {
            _fileContentBuilder
                .AppendNewLine()
                .AppendNewRequest()
                .AppendNewLine()
                .AppendGetMethod()
                .AppendText(path)
                .AppendText(parametersBuilder.GetAsQueryParameters())
                .AppendNewLine();
            return;
        }

        _fileContentBuilder
            .AppendNewLine()
            .AppendNewRequest()
            .AppendNewLine()
            .AppendGetMethod()
            .AppendText(path)
            .AppendNewLine();
    }

    public void SetDeleteRequest(DeleteRequest request)
    {
        parametersBuilder.SetParameters(request.Parameters);
        if (parametersBuilder.IsParametersExists())
        {
            _fileContentBuilder.AppendText(parametersBuilder.GetAsVariable());
        }
        
        var path = request.Path.Replace("{", "{{").Replace("}", "}}");

        if (parametersBuilder.IsQueryParameters())
        {
            _fileContentBuilder
                .AppendNewLine()
                .AppendNewRequest()
                .AppendNewLine()
                .AppendDeleteMethod()
                .AppendText(path)
                .AppendText(parametersBuilder.GetAsQueryParameters())
                .AppendNewLine();
            return;
        }

        _fileContentBuilder
            .AppendNewLine()
            .AppendNewRequest()
            .AppendNewLine()
            .AppendDeleteMethod()
            .AppendText(path)
            .AppendNewLine();
    }

    public void SetPostRequest(PostRequest request)
    {        
        parametersBuilder.SetParameters(request.Parameters);
        if (parametersBuilder.IsParametersExists())
        {
            _fileContentBuilder.AppendText(parametersBuilder.GetAsVariable());
        }

        var path = request.Path.Replace("{", "{{").Replace("}", "}}");
        
        if (parametersBuilder.IsQueryParameters())
        {        
            _fileContentBuilder
                .AppendNewLine()
                .AppendNewRequest()
                .AppendNewLine()
                .AppendPostMethod()
                .AppendText(path)
                .AppendText(parametersBuilder.GetAsQueryParameters())
                .AppendNewLine()
                .AppendContentType(request.ContentType)
                .AppendNewLine()
                .AppendNewLine();
        }
        else
        {
            _fileContentBuilder
                .AppendNewLine()
                .AppendNewRequest()
                .AppendNewLine()
                .AppendPostMethod()
                .AppendText(request.Path)
                .AppendNewLine()
                .AppendContentType(request.ContentType)
                .AppendNewLine()
                .AppendNewLine();
        }
        
        if (!string.IsNullOrWhiteSpace(request.Reference))
        {
            var bodyComponentType = request.Reference.Split('/').Last();
            var component = bodyComponentsStorage.GetByName(bodyComponentType);
            _fileContentBuilder
                .AppendText(bodyComponentFileBuilder.Build(component))
                .AppendNewLine();
        }
    }

    public void SetPatchRequest(PatchRequest request)
    {
        parametersBuilder.SetParameters(request.Parameters);
        if (parametersBuilder.IsParametersExists())
        {
            _fileContentBuilder.AppendText(parametersBuilder.GetAsVariable());
        }

        var path = request.Path.Replace("{", "{{").Replace("}", "}}");
        if (parametersBuilder.IsQueryParameters())
        {        
            _fileContentBuilder
                .AppendNewLine()
                .AppendNewRequest()
                .AppendNewLine()
                .AppendPatchMethod()
                .AppendText(path)
                .AppendText(parametersBuilder.GetAsQueryParameters())
                .AppendNewLine()
                .AppendContentType(request.ContentType)
                .AppendNewLine()
                .AppendNewLine();
        }
        else
        {
            _fileContentBuilder
                .AppendNewLine()
                .AppendNewRequest()
                .AppendNewLine()
                .AppendPatchMethod()
                .AppendText(path)
                .AppendNewLine()
                .AppendContentType(request.ContentType)
                .AppendNewLine()
                .AppendNewLine();
        }
        
        if (!string.IsNullOrWhiteSpace(request.Reference))
        {
            var bodyComponentType = request.Reference.Split('/').Last();
            var component = bodyComponentsStorage.GetByName(bodyComponentType);
            _fileContentBuilder
                .AppendText(bodyComponentFileBuilder.Build(component))
                .AppendNewLine();
        }
    }

    public void SetPutRequest(PutRequest request)
    {
        parametersBuilder.SetParameters(request.Parameters);
        if (parametersBuilder.IsParametersExists())
        {
            _fileContentBuilder.AppendText(parametersBuilder.GetAsVariable());
        }

        var path = request.Path.Replace("{", "{{").Replace("}", "}}");
        if (parametersBuilder.IsQueryParameters())
        {        
            _fileContentBuilder
                .AppendNewLine()
                .AppendNewRequest()
                .AppendNewLine()
                .AppendPutMethod()
                .AppendText(path)
                .AppendText(parametersBuilder.GetAsQueryParameters())
                .AppendNewLine()
                .AppendContentType(request.ContentType)
                .AppendNewLine()
                .AppendNewLine();
        }
        else
        {
            _fileContentBuilder
                .AppendNewLine()
                .AppendNewRequest()
                .AppendNewLine()
                .AppendPutMethod()
                .AppendText(path)
                .AppendNewLine()
                .AppendContentType(request.ContentType)
                .AppendNewLine()
                .AppendNewLine();
        }
        
        if (!string.IsNullOrWhiteSpace(request.Reference))
        {
            var bodyComponentType = request.Reference.Split('/').Last();
            var component = bodyComponentsStorage.GetByName(bodyComponentType);
            _fileContentBuilder
                .AppendText(bodyComponentFileBuilder.Build(component))
                .AppendNewLine();
        }
    }

    public string Build()
        => _fileContentBuilder.ToString();
}
