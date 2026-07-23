using System.Net.Http.Json;
using Microsoft.Extensions.Logging;
using PaymentNET.Contracts;
using Microsoft.AspNetCore.WebUtilities;
namespace PaymentNET.Helper;

public sealed class RestClient : IRestClient
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<RestClient> _logger;

    public RestClient(HttpClient httpClient, ILogger<RestClient> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    public async Task<TResponse> PostAsync<TRequest, TResponse>(
        string endpoint,
        TRequest request,
        RestRequestOptions? options = null,
        CancellationToken cancellationToken = default)
    {
        using var requestMessage = CreateRequest(
            HttpMethod.Post,
            endpoint,
            options);

        requestMessage.Content = JsonContent.Create(request);
        _logger.LogInformation("Invoking HTTP Request");
        var response = await _httpClient.SendAsync(
            requestMessage,
            cancellationToken);
        _logger.LogInformation("Request Finished with code:{Code}",response.StatusCode);
        if (!response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadAsStringAsync(cancellationToken);
            _logger.LogInformation("Failed HTTP Request Error:{result}",result);
         throw  new Exception(result);
        }

        return await response.Content
            .ReadFromJsonAsync<TResponse>(cancellationToken)?? throw new Exception("Failed HTTP Request Error");
    }

    public async Task<TResponse> GetAsync<TResponse>(
        string endpoint,
        RestRequestOptions? options = null,
        CancellationToken cancellationToken = default)
    {
        using var requestMessage = CreateRequest(
            HttpMethod.Get,
            endpoint,
            options);

        var response = await _httpClient.SendAsync(
            requestMessage,
            cancellationToken);

        response.EnsureSuccessStatusCode();

        return await response.Content
            .ReadFromJsonAsync<TResponse>(cancellationToken)?? throw new Exception("Failed HTTP Request Error");
    }

    public async Task<TResponse> GetAsync<TResponse>(
        string endpoint, 
        object? queries = null, 
        CancellationToken cancellationToken = default)
    {
        var uri = BuildUriWithQuery(endpoint, queries);

        using var requestMessage = CreateRequest(HttpMethod.Get, uri, options: null);

        _logger.LogInformation("Invoking HTTP Request to {Uri}", uri);

        var response = await _httpClient.SendAsync(requestMessage, cancellationToken);

        _logger.LogInformation("Request Finished with code:{Code}", response.StatusCode);

        if (!response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadAsStringAsync(cancellationToken);
            _logger.LogInformation("Failed HTTP Request Error:{result}", result);
            throw new Exception(result);
        }

        return await response.Content.ReadFromJsonAsync<TResponse>(cancellationToken) 
               ?? throw new Exception("Failed HTTP Request Error");
    }

    private static string BuildUriWithQuery(string endpoint, object? queries)
    {
        if (queries is null)
            return endpoint;

        var queryParams = queries.GetType()
            .GetProperties()
            .Where(p => p.GetValue(queries) != null)
            .ToDictionary(
                p => p.Name,
                p => p.GetValue(queries)?.ToString()
            );

        if (!queryParams.Any())
            return endpoint;

        return QueryHelpers.AddQueryString(endpoint, queryParams!);
    }
    
    private static HttpRequestMessage CreateRequest(
        HttpMethod method,
        string endpoint,
        RestRequestOptions? options)
    {
        var requestMessage = new HttpRequestMessage(
            method,
            endpoint);

        if (options is not { Headers: not null }) return requestMessage;
        foreach (var header in options.Headers)
        {
            requestMessage.Headers.TryAddWithoutValidation(
                header.Key,
                header.Value);
        }

        return requestMessage;
    }
}