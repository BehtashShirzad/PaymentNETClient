using System.Threading;
using System.Threading.Tasks;
using PaymentNET.Standard.Dtos.Requests;
using PaymentNET.Standard.Dtos.Responses;

namespace PaymentNET.Standard.Contracts
{
    public interface IPaymentService
    {
        Task<CreatePaymentResponseDto> CreatePaymentRequest(
            PaymentRequestDto request,
            CancellationToken cancellationToken = default);
        
    }
}