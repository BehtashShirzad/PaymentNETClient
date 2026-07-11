namespace PaymentNET.Providers.ZarinPal
{
    public   class ZarinPalOptions
    {
        public string MerchantId { get; set; } = string.Empty;
        public bool Sandbox { get; set; }
        public string BaseUrl { get; set; } = "https://payment.zarinpal.com";
    }
}