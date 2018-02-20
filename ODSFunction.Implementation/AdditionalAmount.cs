using Newtonsoft.Json;
using System.Collections.Generic;

namespace ODSFunction.Implementation
{
    public class AdditionalAmount
    {
        public double? DiscountAmount { get; set; }
        public double? CashbackAmount { get; set; }
        public double? TaxableAmount { get; set; }
        public double? TipAmount { get; set; }
        public double? TipPercentage { get; set; }
        public double? CharityAmount { get; set; }
        public string CharitySelection { get; set; }
        [JsonIgnore]
        public string CharityRoundUpFlag { get; set; }
        public double? MerchantAmountField1 { get; set; }
        public string MerchantAmountFieldDescription1 { get; set; }
        public double? MerchantAmountField2 { get; set; }
        public string MerchantAmountFieldDescription2 { get; set; }

        // from TicketInfo's TicketInfoAdditionalAmount
        public double? SubtotalAmount { get; set; }                  // required
        public double? TaxAmount { get; set; }                       // optional
        public double? TippableAmount { get; set; }                  // optional
        public List<TipPercentage> TipPercentages { get; set; }     // optional
        public List<TipAmount> TipAmounts { get; set; }             // optional
        public double? TipAmountMerchantSpecified { get; set; }      // optional
        public string TipDescription { get; set; }                  // optional
        public List<CharityOption> CharityOptions { get; set; }     // optional
    }

    public class TipPercentage
    {
        public double? SuggestedTipPercentage { get; set; }
        public bool DefaultTipPercentage { get; set; }              // MJ: I believe this should be a bool, BB: per MCX is double
    }

    public class TipAmount
    {
        public double? SuggestedTipAmount { get; set; }
        public bool DefaultTipAmount { get; set; }                  // MJ: I believe this should be a bool, BB: per MCX is double
    }

    public class CharityOption
    {
        public string CharityName { get; set; }
        public string CharityProgramText { get; set; }
        public double? SuggestedCharityAmount { get; set; }

        public bool CharityRoundUpFlag { get; set; }
        public string CharityLogoURL { get; set; }
    }
}
