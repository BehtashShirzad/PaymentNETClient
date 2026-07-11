using PaymentNET.Standard.Contracts;
using PaymentNET.Standard.Dtos.Requests;

namespace PaymentNET.Providers.ZarinPal;

public class ZarinPalPaymentService:IPaymentService
{
    public Task CreatePaymentRequest(PaymentRequestDto paymentRequestDto)
    {
        throw new NotImplementedException();
    }
}