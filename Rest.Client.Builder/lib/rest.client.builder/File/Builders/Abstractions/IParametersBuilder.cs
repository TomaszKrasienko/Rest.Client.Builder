namespace rest.client.builder.File.Builders.Abstractions;

internal interface IParametersBuilder
{
    void SetParameters(Dictionary<string, string> parameters);
    bool IsParametersExists();
    string GetAsVariable();
    bool IsQueryParameters();
    string GetAsQueryParameters();
}