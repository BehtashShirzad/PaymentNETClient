using System.Collections.Generic;
using PaymentNET.Standard.Attributes;
using PaymentNET.Standard.Enums;

namespace PaymentNET.Standard.Dtos.Requests
{
    /// <summary>
    /// Represents a payment request.
    /// </summary>
    public class PaymentRequestDto
    {
        public string Description { get; set; } = string.Empty;
        public CurrencyType CurrencyType { get; set; } = CurrencyType.IRanianRial;
        public int Amount { get; set; }
        public string CallBackUrl { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the merchant identifier.
        /// </summary>
        /// <exception cref="Exceptions.UnsupportedProviderOptionException"> Throw if used with any other payment provider.</exception>
        [SupportedProviders(PaymentProvider.ZarinPal)]
        public string MerchantId { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the referrer identifier.
        /// </summary>
        /// <exception cref="Exceptions.UnsupportedProviderOptionException"> Throw if used with any other payment provider.</exception>
        [SupportedProviders(PaymentProvider.ZarinPal)]
        public string ReferrerId { get; set; } = string.Empty;

        public Dictionary<string, string> AdditionalData { get; set; } = new Dictionary<string, string>();

        /// <summary>
        /// Gets or sets the payer mobile number.
        /// </summary>
        /// <exception cref="Exceptions.UnsupportedProviderOptionException"> Throw if used with any other payment provider.</exception>
        [SupportedProviders(PaymentProvider.ZarinPal)]
        public string PayerMobileNumber { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the payer email.
        /// </summary>
        /// <exception cref="Exceptions.UnsupportedProviderOptionException"> Throw if used with any other payment provider.</exception>
        [SupportedProviders(PaymentProvider.ZarinPal)]
        public string PayerEmail { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the order identifier.
        /// </summary>
        /// <exception cref="Exceptions.UnsupportedProviderOptionException"> Throw if used with any other payment provider.</exception>
        [SupportedProviders(PaymentProvider.ZarinPal)]
        public string OrderId { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the wage amount.
        /// </summary>
        /// <exception cref="Exceptions.UnsupportedProviderOptionException"> Throw if used with any other payment provider.</exception>
        [SupportedProviders(PaymentProvider.Jibit)]
        public int Wage { get; set; }

        /// <summary>
        /// Gets or sets whether the payer mobile number should be validated.
        /// </summary>
        /// <exception cref="Exceptions.UnsupportedProviderOptionException"> Throw if used with any other payment provider.</exception>
        [SupportedProviders(PaymentProvider.Jibit)]
        public bool CheckPayerMobileNumber { get; set; }

        /// <summary>
        /// Gets or sets the client reference number.
        /// </summary>
        /// <exception cref="Exceptions.UnsupportedProviderOptionException"> Throw if used with any other payment provider.</exception>
        [SupportedProviders(PaymentProvider.Jibit)]
        public string ClientReferenceNumber { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the payer card number.
        /// </summary>
        /// <exception cref="Exceptions.UnsupportedProviderOptionException"> Throw if used with any other payment provider.</exception>
        [SupportedProviders(PaymentProvider.Jibit)]
        public string PayerCardNumber { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the payer reference identifier.
        /// </summary>
        /// <exception cref="Exceptions.UnsupportedProviderOptionException"> Throw if used with any other payment provider.</exception>
        [SupportedProviders(PaymentProvider.Jibit)]
        public string PayerReferenceIdentifier { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the switching configuration.
        /// </summary>
        /// <exception cref="Exceptions.UnsupportedProviderOptionException"> Throw if used with any other payment provider.</exception>
        [SupportedProviders(PaymentProvider.Jibit)]
        public Switching Switching { get; set; } = new Switching();
    }
}