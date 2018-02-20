using System;
using System.Text.RegularExpressions;

namespace ODSFunction.Implementation
{
    public class OLSTransactionData
    {
        public string ProcessingCode { get; set; }

        public DateTime TransmissionDate { get; set; }

        public string SystemsTraceAuditNumber { get; set; }

        public DateTime SettlementDate { get; set; }

        public string CardSequenceNumber { get; set; }

        public double TransactionFeeAmount { get; set; }

        public string AcquiringIdCode { get; set; }

        public string ForwardingIdCode { get; set; }

        public string NetworkManagementInfoCode { get; set; }

        public string AlternateMerchantId { get; set; }

        [Obsolete]
        public string TicketId { get; set; }

        public string CheckOutToken { get; set; }

        public string MerchantTicketId { get; set; }

        public string WalletId { get; set; }

        public string TransactionReferenceKey { get; set; }

        public string DigitalSessionId { get; set; }

        public ReplacementAmounts ReplacementAmounts { get; set; }

        public string ExternalPOSId { get; set; }
    }

    public class ReplacementAmounts
    {
        public ReplacementAmounts() { }
        public ReplacementAmounts(string isoValue)
        {
            if (string.IsNullOrWhiteSpace(isoValue) && isoValue.Length == 42)
            {
                TransactionAmount = ParseAmount(isoValue.Substring(0, 12));
                SettlementAmount = ParseAmount(isoValue.Substring(12, 12));
                TransactionFee = ParseAmount(isoValue.Substring(24, 9));
                SettlementFee = ParseAmount(isoValue.Substring(33, 9));
            }
        }

        public double TransactionAmount { get; set; }
        public double SettlementAmount { get; set; }
        public double TransactionFee { get; set; }
        public double SettlementFee { get; set; }

        public override string ToString()
        {
            var amountString = string.Empty;

            amountString += FormatAmount(TransactionAmount, AmountType.Amount);
            amountString += FormatAmount(SettlementAmount, AmountType.Amount);

            amountString += FormatAmount(TransactionFee, AmountType.Fee);
            amountString += FormatAmount(SettlementFee, AmountType.Fee);

            // only return if the string contains non-0 values
            if (Regex.Match(amountString, @"[1-9]").Success)
            {
                return amountString;
            }

            return null;
        }

        private double ParseAmount(string amountString)
        {
            double testAmount = 0;

            switch (amountString.Length)
            {
                case 12: // amount
                    if (double.TryParse(amountString, out testAmount))
                    {
                        return testAmount / 100;
                    }
                    break;
                case 9: // fee
                    if (double.TryParse(amountString.Replace("D", "-").Replace("C", string.Empty), out testAmount))
                    {
                        return testAmount / 100;
                    }
                    break;
            }

            return default(double);
        }

        private string FormatAmount(double amount, AmountType amountType)
        {
            var formattedAmount = string.Empty;

            switch (amountType)
            {
                case AmountType.Amount:
                    formattedAmount += Math.Round(amount * 100).ToString().PadLeft(12, '0');
                    break;
                case AmountType.Fee:
                    var prefix = "0";
                    if (amount < 0)
                    {
                        prefix = "D";
                        amount *= -1;
                    }
                    else if (amount > 0)
                    {
                        prefix = "C";
                    }
                    formattedAmount += prefix + Math.Round(amount * 100).ToString().PadLeft(8, '0');
                    break;
            }

            return formattedAmount;
        }

        private enum AmountType
        {
            Amount,
            Fee
        }

    }
}
