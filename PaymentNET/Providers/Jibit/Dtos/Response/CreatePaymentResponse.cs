namespace PaymentNET.Providers.Jibit.Dtos.Response;

public class CreatePaymentResponse
{
    public long PurchaseId { get; set; }

    public string PurchaseIdStr { get; set; } = default!;

    public string ClientReferenceNumber { get; set; } = default!;

    public string PspSwitchingUrl { get; set; } = default!;

    public long? Fee { get; set; }

    public long? AffiliateFee { get; set; }

    public long ShaparakFee { get; set; }

    public long NetAmount { get; set; }

    public long PayableAmount { get; set; }

    public string Currency { get; set; } = default!;
}