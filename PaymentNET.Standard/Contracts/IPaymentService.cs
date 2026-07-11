using System.Threading.Tasks;
using PaymentNET.Standard.Dtos.Requests;

namespace PaymentNET.Standard.Contracts
{
    public interface IPaymentService
    {
        Task CreatePaymentRequest(PaymentRequestDto paymentRequestDto);
        
    }
}