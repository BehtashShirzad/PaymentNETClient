namespace PaymentNET.Providers.Jibit;

public class JibitEndpoints
{
    public const string Token = "/v1/authentication/login";

    public const string PaymentRequest = "/v1/payment/create";

    public const string PaymentVerify = "/v1/payment/verify";

    public const string PaymentInquiry = "/v1/payment/inquiry";
}