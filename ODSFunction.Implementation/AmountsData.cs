using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODSFunction.Implementation
{
    public class AmountsData
    {
        public AmountsData() { }

        public AmountsData(string isoValues)
        {
            var chunkSize = 20;
            for (var i = 0; i < isoValues.Length / chunkSize; i++)
            {
                var chunk = isoValues.Substring(i * chunkSize, chunkSize);
                var accountType = chunk.Substring(0, 2);
                var amountType = chunk.Substring(2, 2);
                var currencyType = chunk.Substring(4, 3);
                var amountString = chunk.Substring(7, 13).Replace("C", "-").Replace("D", string.Empty);
                double amount = 0;
                if (double.TryParse(amountString, out amount))
                {
                    // get back to dollars + cents
                    amount /= 100;
                    switch (amountType)
                    {
                        case "36":
                            this.Tax = amount;
                            break;
                        case "37":
                            this.Tip = amount;
                            break;
                        case "38":
                            this.Discount = amount;
                            break;
                        case "40":
                            this.Cashback = amount;
                            break;
                    }
                }
            }
        }

        public double Tax { get; set; }
        public double Cashback { get; set; }
        public double Tip { get; set; }
        public double Discount { get; set; }

        public override string ToString()
        {
            var stringValue = string.Empty;

            stringValue += FormatAmount(this.Discount, "38");
            stringValue += FormatAmount(this.Tax, "36");
            stringValue += FormatAmount(this.Tip, "37");
            stringValue += FormatAmount(this.Cashback, "40");

            return string.IsNullOrEmpty(stringValue) ? null : stringValue;
        }

        private string FormatAmount(double amount, string amountType = "00")
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            if (amount == default(double)) return string.Empty;

            var formattedAmount = "00"; // default account type
            formattedAmount += amountType;
            formattedAmount += "840"; // default currency code (TBD) 

            var prefix = "D";
            if (amount < 0)
            {
                prefix = "C";
                amount *= -1;
            }

            formattedAmount += prefix + Math.Round(amount * 100).ToString().PadLeft(12, '0');

            return formattedAmount;
        }
    }
}
