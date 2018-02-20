using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODSFunction.Implementation
{
    public class FuelSiteUpsellSelection
    {
        public string ProductCode { get; set; }
        public string ProductDescription { get; set; }
        public string ProductCategory { get; set; }
        public double Quantity { get; set; }
        public double UnitPrice { get; set; }
        public Dictionary<string, JObject> AdditionalInfo { get; set; }
    }

    public class FuelSiteSelection
    {
        public string SiteID { get; set; }
        public string PumpNumber { get; set; }

        private string _receiptRequested;
        /// <summary>
        /// Implementing explicit get/set methods to coerce existing data (boolean) into new String datatype
        /// </summary>
        public string ReceiptRequested
        {
            get { return _receiptRequested; }
            set
            {
                var testValue = ReceiptRequestType.NoReceipt;
                if (Enum.TryParse<ReceiptRequestType>(value, true, out testValue))
                {
                    _receiptRequested = testValue.ToString();
                }
            }
        }

        public List<FuelSiteUpsellSelection> FuelSiteUpsellSelections { get; set; }
        public Dictionary<string, JObject> AdditionalInfo { get; set; }
    }

    public enum ReceiptRequestType
    {
        PrintReceipt,
        NoReceipt
    }
}
