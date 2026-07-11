using Microsoft.Extensions.Caching.Hybrid;
using PaymentNET.Contracts;

namespace PaymentNET.Infrastructure;

internal sealed class HybridTokenCache : ITokenCache
{
    private readonly HybridCache _cache;

    public HybridTokenCache(HybridCache cache)
    {
        _cache = cache;
    }


    public async Task<T?> GetAsync<T>(
        string key,
        CancellationToken cancellationToken = default)
    {
        return await _cache.GetOrCreateAsync<T?>(
            key,
            _ => ValueTask.FromResult<T?>(default),
            cancellationToken: cancellationToken);
    }


    public async Task SetAsync<T>(
        string key,
        T value,
        TimeSpan expiration,
        CancellationToken cancellationToken = default)
    {
        await _cache.SetAsync(
            key,
            value,
            new HybridCacheEntryOptions
            {
                Expiration = expiration
            },
           cancellationToken: cancellationToken);
    }
}