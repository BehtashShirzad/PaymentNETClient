namespace PaymentNET.Providers.Jibit
{
    public   class JibitOptions
    {
        public string ApiKey { get; set; } = string.Empty;
        public string SecretKey { get; set; } = string.Empty;
        public string BaseUrl { get; set; } = "https://napi.jibit.ir";
    }
}