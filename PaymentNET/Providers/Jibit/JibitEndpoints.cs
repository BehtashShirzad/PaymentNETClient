namespace PaymentNET.Providers.Jibit;

public class JibitEndpoints
{
    public const string Token = "/ppg/v3/tokens";

    public const string PaymentRequest = "/ppg/v3/purchases";

    public const string PaymentVerify = "/ppg/v3/purchases/{purchase_id}/verify";

    public const string PaymentInquiry = "/v1/payment/inquiry";
}