using Mapster;
using Microsoft.Extensions.Logging;
using PaymentNET.Contracts;
using PaymentNET.Providers.Jibit.Dtos.Requests;
using PaymentNET.Providers.Jibit.Dtos.Response;
using PaymentNET.Standard.Contracts;
using PaymentNET.Standard.Dtos.Requests;
using PaymentNET.Standard.Dtos.Responses;

namespace PaymentNET.Providers.Jibit;

public sealed class JibitPaymentService : IPaymentService
{
    private readonly IRestClient _restClient;
    private readonly ILogger<JibitPaymentService> _logger;


    public JibitPaymentService(ILogger<JibitPaymentService> logger,
        IRestClient restClient)
    {
        _restClient = restClient;
        _logger = logger;
    }


    public async Task<CreatePaymentResponseDto> CreatePaymentRequest(
        PaymentRequestDto paymentRequestDto,
        CancellationToken cancellationToken = default)
    {
        var dto = paymentRequestDto.Adapt<CreatePaymentRequest>();
     
        var response =
            await _restClient.PostAsync<
                CreatePaymentRequest,
                CreatePaymentResponse>(
                JibitEndpoints.PaymentRequest,
                dto,
                cancellationToken: cancellationToken);


        return response.Adapt<CreatePaymentResponseDto>();
    }
}