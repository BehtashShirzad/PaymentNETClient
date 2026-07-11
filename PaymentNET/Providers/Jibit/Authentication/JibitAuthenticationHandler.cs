using System.Net.Http.Headers;

namespace PaymentNET.Providers.Jibit.Authentication;

internal sealed class JibitAuthenticationHandler 
    : DelegatingHandler
{
    private readonly IJibitTokenProvider _tokenProvider;


    public JibitAuthenticationHandler(
        IJibitTokenProvider tokenProvider)
    {
        _tokenProvider = tokenProvider;
    }


    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        var token = await _tokenProvider
            .GetAccessTokenAsync(cancellationToken);


        request.Headers.Authorization =
            new AuthenticationHeaderValue(
                "Bearer",
                token);


        return await base.SendAsync(
            request,
            cancellationToken);
    }
}