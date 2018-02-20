using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODSFunction.Implementation
{
    public class TenderAuthResponse
    {
        public string ApprovalCode { get; set; }

        public string MCXResponseCode { get; set; }

        public string IssuerResponseCode { get; set; }

        public string AdditionalResponseData { get; set; }

        public string CardVerificationCodeResponse { get; set; }

        public string AVSResponseCode { get; set; }

        public double TotalAuthorizedAmount { get; set; }

        public double OriginalAuthorizationAmount { get; set; }

        public double AccountBalanceAmount { get; set; }

        public string AuthorizerTransactionId { get; set; }

        public string ReceivingInstitutionIdCode { get; set; }

        /// <summary>
        /// NOTE: This ISO field mapping is intended to be INBOUND only, values returned from OLS
        /// </summary>
        public string AdditionalAmounts
        {
            get
            {
                // NOTE: even though this field is intended to be INBOUND from OLS, this code is here to 
                // support the SocketClient running in emulator mode.  That logic builds a TenderAuthResponse,
                // and this code must allow that object to serialize into an ISO field
                var stringValue = string.Empty;

                stringValue += FormatAmount(this.TotalAuthorizedAmount, "58");
                stringValue += FormatAmount(this.AccountBalanceAmount, "02");

                return string.IsNullOrEmpty(stringValue) ? null : stringValue;
            }
            set
            {
                var isoValues = value;
                if (string.IsNullOrWhiteSpace(isoValues)) return;

                var chunkSize = 20;
                for (var i = 0; i < isoValues.Length / chunkSize; i++)
                {
                    var chunk = isoValues.Substring(i * chunkSize, chunkSize);
                    var accountType = chunk.Substring(0, 2);
                    var amountType = chunk.Substring(2, 2);
                    var currencyType = chunk.Substring(4, 3);
                    var amountString = chunk.Substring(7, 13).Replace("D", "-").Replace("C", string.Empty);
                    double amount = 0;
                    if (double.TryParse(amountString, out amount))
                    {
                        // get back to dollars + cents
                        amount /= 100;
                        switch (amountType)
                        {
                            case "02":
                                this.AccountBalanceAmount = amount;
                                break;
                            case "58":
                                this.TotalAuthorizedAmount = amount;
                                break;
                        }
                    }
                }
            }
        }

        private string FormatAmount(double amount, string amountType = "11")
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            if (amount == default(double)) return string.Empty;

            var formattedAmount = "99"; // default account type
            formattedAmount += amountType;
            formattedAmount += "840"; // default currency code (TBD) 

            var prefix = "C";
            if (amount < 0)
            {
                prefix = "D";
                amount *= -1;
            }

            formattedAmount += prefix + Math.Round(amount * 100).ToString().PadLeft(12, '0');

            return formattedAmount;
        }

    }
}
