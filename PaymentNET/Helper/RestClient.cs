using System.Net.Http.Json;
using PaymentNET.Contracts;

namespace PaymentNET.Helper;

public sealed class RestClient : IRestClient
{
    private readonly HttpClient _httpClient;

    public RestClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<TResponse?> PostAsync<TRequest, TResponse>(
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

        var response = await _httpClient.SendAsync(
            requestMessage,
            cancellationToken);

        response.EnsureSuccessStatusCode();

        return await response.Content
            .ReadFromJsonAsync<TResponse>(cancellationToken);
    }

    public async Task<TResponse?> GetAsync<TResponse>(
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
            .ReadFromJsonAsync<TResponse>(cancellationToken);
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