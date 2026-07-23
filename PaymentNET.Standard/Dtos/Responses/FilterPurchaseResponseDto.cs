using System.Collections.Generic;

namespace PaymentNET.Standard.Dtos.Responses
{
    
    
    public class FilterPurchaseResponseDto
{
    public int PageNumber { get; set; }
    public int Size { get; set; }
    public int NumberOfElements { get; set; }
    public bool HasNext{get; set;}
    public bool HasPrevious{get; set;}
    public List<Element> Elements{get; set;}
    
}

public class Element
{
    public long PurchaseId { get; set; }
    public string PurchaseIdStr{get; set;}
    public string ClientCode{get; set;}
    public long Amount{get; set;}
    public long Wage{get; set;}
    public long Fee{get; set;}
    public string FeePaymentType{get; set;}
    public long ShaparakFee{get; set;}
    public long AffiliateFee{get; set;}
    public long NetAmount{get; set;}
    public string ResellerCode{get; set;}
    public string Currency{get; set;}
    public string CallbackUrl{get; set;}
    public string State{get; set;}
    public string ClientReferenceNumber{get; set;}
    public string PspName{get; set;}
    public string PspRrn{get; set;}
    public string PspReferenceNumber{get; set;}
    public string PspTraceNumber{get; set;}
    public string ExpirationDate{get; set;}
    public string UserIdentifier{get; set;}
    public string PayerMobileNumber{get; set;}
    public string PayerCardNumber{get; set;}
    public string PayerNationalCode{get; set;}
    public string Description{get; set;}
    public string? AdditionalData{get; set;}
    public string PspMaskedCardNumber{get; set;}
    public string PspHashedCardNumber{get; set;}
    public string PspCardOwner{get; set;}
    public List<PspFailReason>? PspFailReasons{get; set;}
    public string InitPayerIp{get; set;}
    public string RedirectPayerIp{get; set;}
    public bool PspSettled{get; set;}
    public bool Refunded{get; set;}
    public long RefundableAmount{get; set;}
    public string CreatedAt{get; set;}
    public string BillingDate{get; set;}
    public string VerifiedAt{get; set;}
    public string PspSettledAt{get; set;}
    public long SettlementId{get; set;}
    public bool HasContradiction{get; set;}
}

public class PspFailReason
{
    public int Code{get; set;}
    public string Description{get; set;}
}
}