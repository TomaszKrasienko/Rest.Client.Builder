using System.Net.Http.Json;
using Microsoft.Extensions.Logging;
using rest.client.builder.Exceptions;
using rest.client.builder.OpenApi.Communication.Clients.Abstractions;
using rest.client.builder.OpenApi.Models;

namespace rest.client.builder.OpenApi.Communication.Clients;

internal sealed class OpenApiClient : IOpenApiClient
{
    private readonly ILogger<OpenApiClient> _logger;
    private readonly HttpClient _httpClient;
    private readonly string _openApiPath;
    
    public OpenApiClient(ILogger<OpenApiClient> logger, HttpClient httpClient, string openApiPath)
    {
        _logger = logger;
        _httpClient = httpClient;
        _openApiPath = openApiPath;
    }
    
    public async Task<OpenApiDocument> GetOpenApiDocumentation()
    {
        try
        {
            var response = await _httpClient.GetAsync(_openApiPath);
            if (!response.IsSuccessStatusCode)
            {
                throw new InvalidOpenApiDocumentationResponseException();
            }
            else
            {
                return await response.Content.ReadFromJsonAsync<OpenApiDocument>();
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            throw;
        }
    }
}