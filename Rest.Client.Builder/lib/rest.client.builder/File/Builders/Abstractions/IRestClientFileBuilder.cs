using rest.client.builder.Requests.Models;

namespace rest.client.builder.File.Builders.Abstractions;

internal interface IRestClientFileBuilder
{
    void SetAddress(string address);
    void SetGetRequest(GetRequest request);
    void SetDeleteRequest(DeleteRequest request);
    void SetPostRequest(PostRequest request);
    void SetPatchRequest(PatchRequest request);
    void SetPutRequest(PutRequest request);
    string Build();
}