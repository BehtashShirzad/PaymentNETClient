using PaymentNET.Standard.Contracts;
using PaymentNET.Standard.Dtos.Requests;
using PaymentNET.Standard.Dtos.Responses;

namespace PaymentNET.Providers.ZarinPal;

public class ZarinPalPaymentService:IPaymentService
{
   

    public Task<CreatePaymentResponseDto> CreatePaymentRequest(PaymentRequestDto request, CancellationToken cancellationToken = default)
    {
        return Task.FromResult(new CreatePaymentResponseDto());
       
    }

    public Task<FilterPurchaseResponseDto> FilterPurchase(GetPurchasesRequestDto? request = null, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}