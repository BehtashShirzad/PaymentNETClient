namespace PaymentNET.Contracts;

public interface IRestClient
{
    Task<TResponse?> PostAsync<TRequest, TResponse>(
        string endpoint,
        TRequest request,
        RestRequestOptions? options = null,
        CancellationToken cancellationToken = default);

    Task<TResponse?> GetAsync<TResponse>(
        string endpoint,
        RestRequestOptions? options = null,
        CancellationToken cancellationToken = default);
}