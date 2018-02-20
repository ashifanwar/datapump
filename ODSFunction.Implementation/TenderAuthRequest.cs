using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODSFunction.Implementation
{
    public class TenderAuthRequest
    {
        public string MCXMerchantID { get; set; }

        public string TerminalID { get; set; }

        public double Amount { get; set; }

        public string MerchantReferenceId { get; set; }

        public string MerchantCategoryCode { get; set; }

        public string POSEntryMode { get; set; }

        public string CurrencyCode { get; set; }

        public string NationalPOSConditionCode { get; set; }

        public DateTime ExternalBusinessDate { get; set; }

        public string ExternalBusinessDayGroup { get; set; }

        public string ReversalReasonCode { get; set; }

        public string MerchantDefinedData { get; set; }

        public string PartialAuthIndicator { get; set; }

        public string OrderNumber { get; set; }

        public string PromoRequest { get; set; }

        public double CashbackAmount { get; set; }
    }
}
