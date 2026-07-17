using System.Net.Http.Json;
using Microsoft.Extensions.Options;
using PaymentNET.Contracts;
using PaymentNET.Standard.Exceptions;

namespace PaymentNET.Providers.Jibit.Authentication;

internal sealed class JibitTokenProvider : IJibitTokenProvider
{
    private const string CacheKey = "paymentnet:jibit:access-token";

    private   readonly SemaphoreSlim _semaphore = new(1, 1);

    private readonly IHttpClientFactory _httpClientFactory;
    private readonly JibitOptions _options;
    private readonly ITokenCache _cache;


    public JibitTokenProvider(
        IHttpClientFactory httpClientFactory,
        IOptions<JibitOptions> options,
        ITokenCache cache)
    {
        _httpClientFactory = httpClientFactory;
        _options = options.Value;
        _cache = cache;
    }


    public async Task<string> GetAccessTokenAsync(
        CancellationToken cancellationToken = default)
    {
        var cachedToken = await _cache.GetAsync<string>(
            CacheKey,
            cancellationToken);

        if (!string.IsNullOrWhiteSpace(cachedToken))
        {
            return cachedToken;
        }


        await _semaphore.WaitAsync(cancellationToken);

        try
        {

            cachedToken = await _cache.GetAsync<string>(
                CacheKey,
                cancellationToken);

            if (!string.IsNullOrWhiteSpace(cachedToken))
            {
                return cachedToken;
            }


            var client = _httpClientFactory
                .CreateClient("JibitAuth");


            var response = await client.PostAsJsonAsync(
                JibitEndpoints.Token,
                new
                {
                    apiKey = _options.ApiKey,
                    secretKey = _options.SecretKey
                },
                cancellationToken);


            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync(cancellationToken);
                throw new PaymentException(
                    $"Jibit authentication failed. StatusCode: {response.StatusCode} By Response: {error}");
            }


            var result = await response.Content
                .ReadFromJsonAsync<JibitTokenResponse>(
                    cancellationToken: cancellationToken);


            if (result is null ||
                string.IsNullOrWhiteSpace(result.AccessToken))
            {
                throw new PaymentException(
                    "Jibit returned invalid access token response.");
            }


            var expiration = TimeSpan
                .FromSeconds(
                    result.ExpiresIn > 0
                        ? result.ExpiresIn - 60
                        : 600);


            await _cache.SetAsync(
                CacheKey,
                result.AccessToken,
                expiration,
                cancellationToken);


            return result.AccessToken;
        }
        finally
        {
            _semaphore.Release();
        }
    }


    private sealed class JibitTokenResponse
    {
        public string AccessToken { get; set; } = string.Empty;

        public int ExpiresIn { get; set; }
    }
}