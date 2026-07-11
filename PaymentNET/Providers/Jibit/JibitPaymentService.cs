using PaymentNET.Contracts;
using PaymentNET.Standard.Contracts;
using PaymentNET.Standard.Dtos.Requests;
using PaymentNET.Standard.Dtos.Responses;

namespace PaymentNET.Providers.Jibit;

public sealed class JibitPaymentService : IPaymentService
{
    private readonly IRestClient _restClient;


    public JibitPaymentService(
        IRestClient restClient)
    {
        _restClient = restClient;
    }


    public async Task<CreatePaymentResponseDto> CreatePaymentRequest(
        PaymentRequestDto paymentRequestDto,
        CancellationToken cancellationToken = default)
    {
        var response =
            await _restClient.PostAsync<
                PaymentRequestDto,
                CreatePaymentResponseDto>(
                    JibitEndpoints.PaymentRequest,
                    paymentRequestDto,
                    cancellationToken: cancellationToken);


        if (response is null)
        {
            throw new Exception(
                "Jibit create payment returned empty response.");
        }


        return response;
    }
}