using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODSFunction.Implementation
{
    public class TenderAuth
    {
        public string Id { get; set; }

        public string Status { get; set; }

        public string TenderId { get; set; }

        public string ExternalTenderId { get; set; }

        public string RetrievalReferenceNumber { get; set; }

        public string RequestType { get; set; }

        public DateTime LocalDateTime { get; set; }

        public TenderAuthRequest TenderAuthRequest { get; set; }

        public AmountsData AdditionalAmounts { get; set; }

        public OriginalTenderAuthData OriginalTenderAuthData { get; set; }

        public ProductData[] ProductData { get; set; }

        public Account AccountData { get; set; }

        public EcommerceData EcommerceData { get; set; }

        public CarRentalData CarRentalData { get; set; }

        public LodgingData LodgingData { get; set; }

        public TransportData TransportData { get; set; }

        public TenderAuthResponse TenderAuthResponse { get; set; }

        public RedeemedOffer RedeemedOfferData { get; set; }

        public OLSTransactionData OLSTxData { get; set; }

        public string MerchantName { get; set; }

        public MerchantLocation Location { get; set; }

        public AccountDataInternal AccountDataInternal { get; set; }

        public string WalletItemId { get; set; }

        public string WalletItemTypeId { get; set; }

        public string WalletItemTypeName { get; set; }

        public string ProductDataISOField
        {
            get
            {
                if (this.ProductData != null && this.PumpNumber != null)
                {
                    var output = new StringBuilder();
                    var index = 1;

                    // take up to the first 10 elements in the list
                    foreach (var productData in this.ProductData?.Take(10))
                    {
                        output.Append(FormatAmount(productData.Amount));
                        output.Append(productData.ProductCode.PadLeft(6, '0'));
                        output.Append(FormatAmount(productData.Quantity));
                        output.Append(FormatAmount(productData.UnitPrice));
                        output.Append(this.PumpNumber.PadLeft(4, '0'));
                        output.Append(string.Empty.PadRight(16, ' '));
                        output.Append(productData.Amount > 0 ? "D" : "C");
                        output.Append(productData.UnitOfMeasure);
                        output.Append(index.ToString().PadLeft(2, '0'));

                        index++;
                    }

                    if (output.Length > 0)
                    {
                        return output.ToString();
                    }
                }

                return null;
            }
            set
            {
                System.Diagnostics.Debug.WriteLine(value);

                // TODO: do we want to read the data back??
                /*
                if (value.Length == 0) return;

                try
                {
                    var chunkSize = 57;
                    var chunks = value.Length / chunkSize;
                    if (this.ProductData == null) { this.ProductData = new ProductData[chunks]; }

                    for (var i = 0; i < chunks; i++)
                    {
                        var chunk = value.Substring(i * chunkSize, chunkSize);

                        var amountString = chunk.Substring(0, 9);

                        var productData = new ProductData
                        {
                            //Amount = double.Parse(chunk.Substring)
                        };
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
                */
            }
        }

        /// <summary>
        /// Added as property here for ISO serialization of DE 126/E1
        /// </summary>
        [JsonIgnore]
        public string PumpNumber { get; set; }

        /// <summary>
        /// Convert RequestType to the corresponding ISO MTI
        /// </summary>
        public string MessageTypeIdentifier
        {
            get
            {
                if (string.IsNullOrWhiteSpace(RequestType))
                {
                    var requestType = (TenderAuthType)Enum.Parse(typeof(TenderAuthType), RequestType);
                    switch (requestType)
                    {
                        case TenderAuthType.PreAuth:
                            return "0100";

                        case TenderAuthType.Sale:
                        case TenderAuthType.Refund:
                            return "0200";

                        case TenderAuthType.PartialCompletion:
                        case TenderAuthType.Completion:
                            return "0220";

                        case TenderAuthType.Cancel:
                        case TenderAuthType.Credit:
                        case TenderAuthType.Reversal:
                        case TenderAuthType.Void:
                        case TenderAuthType.PartialReversal:
                            return "0420";
                    }
                }

                return null;
            }
        }

        private string FormatAmount(double amount)
        {
            var formattedAmount = string.Empty;
            var amountParts = amount.ToString().Replace("-", string.Empty).Split('.');
            var wholeAmount = amountParts[0];
            var decimalAmount = string.Empty;

            if (amountParts.Length == 2)
            {
                decimalAmount = amountParts[1];
            }

            formattedAmount = wholeAmount.PadLeft(5, '0') + decimalAmount.PadRight(4, '0');

            System.Diagnostics.Debug.WriteLine($"{amount} -- {formattedAmount}");

            return formattedAmount;
        }
    }

    public enum TenderAuthStatus
    {
        Submitted,
        Approved,
        Declined,
        TimeOut,
        Rejected
    }

    public enum TenderAuthType
    {
        Sale,
        PreAuth,
        Completion,
        Refund,
        Credit,
        Cancel,
        Void,
        Reversal,
        Advice,
        /// <summary>
        /// Advice values are logged in ticket, and not sent to OLS
        /// </summary>
        AdviceSale,
        /// <summary>
        /// Advice values are logged in ticket, and not sent to OLS
        /// </summary>
        AdviceCompletion,
        /// <summary>
        /// Advice values are logged in ticket, and not sent to OLS
        /// </summary>
        AdviceRefund,
        PartialCompletion,
        PartialReversal
    }
}
