namespace PaymentNET.Standard.Dtos.Responses
{
    public class CreatePaymentResponseDto
    {
        public long PurchaseId{get;set;}
        public string PurchaseIdStr{get;set;}
        public string ClientReferenceNumber{get;set;}
        public string PspSwitchingUrl{get;set;}
        public string Fee{get;set;}
        public long  AffiliateFee{get;set;}
        public long  ShaparakFee{get;set;}
        public long  NetAmount{get;set;}
        public long  PayableAmount{get;set;}
        public string  Currency{get;set;}
    }
}