using rest.client.builder.Models;

namespace rest.client.builder.Builders.Abstractions;

internal interface IRestClientFileBuilder
{
    void SetAddress(string address);
    void SetGetRequests(List<GetRequest> requests);
    string Build();
}