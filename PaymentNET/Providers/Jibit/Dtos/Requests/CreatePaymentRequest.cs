using Mapster;
using PaymentNET.Standard.Dtos.Requests;

namespace PaymentNET.Providers.Jibit.Dtos.Requests;

public class CreatePaymentRequest
{
    public decimal Amount { get; set; }

    public string CallBackUrl { get; set; } = default!;

    public string Description { get; set; } = default!;

    public string UserIdentifier { get; set; } = default!;

    [AdaptMember(nameof(PaymentRequestDto.CurrencyType))]
    public string Currency { get; set; } = default!;

    public string ClientReferenceNumber { get; set; } = default!;

    public string? PayerCardNumber { get; set; } = null;
    public Switching? Switching { get; set; } = null;

    public bool CheckPayerMobileNumber { get; set; } = false;

    public int Wage { get; set; } = 0;
}
public class Switching
{
    public List<string> TerminalIds{get;set;}= new List<string>();
    public bool AutoSwitching{get;set;}= false;
}