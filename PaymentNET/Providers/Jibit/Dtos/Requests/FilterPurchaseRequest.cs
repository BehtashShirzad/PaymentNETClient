namespace PaymentNET.Providers.Jibit.Dtos.Requests;

public class FilterPurchaseRequest
{
    public long? PurchaseId { get; set; }
    public string? Status { get; set; }
    public string? ClientReferenceNumber { get; set; }
    public string? PspReferenceNumber { get; set; }
    public string? UserIdentifier { get; set; }
    public string? From { get; set; }
    public string? To { get; set; }
    public int Page { get; set; } = 1;
    public int Size { get; set; } = 25;
}