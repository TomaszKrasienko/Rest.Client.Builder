using rest.client.builder.Requests.Models;

namespace rest.client.builder.File.Builders.Abstractions;

internal interface IRestClientFileBuilder
{
    void SetAddress(string address);
    void SetGetRequest(GetRequest request);
    void SetPostRequest(PostRequest request);
    string Build();
}