namespace PaymentNET.Contracts;

public sealed class RestRequestOptions
{
    public IDictionary<string, string> Headers { get; set; }
        = new Dictionary<string, string>();
    public IDictionary<string, string> Queries { get; set; }
        = new Dictionary<string, string>();
}