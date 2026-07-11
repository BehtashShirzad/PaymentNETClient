namespace PaymentNET.Providers.Jibit.Authentication;

public interface IJibitTokenProvider
{
    Task<string> GetAccessTokenAsync(
        CancellationToken cancellationToken = default);
}