using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODSFunction.Implementation
{
    public class RedeemedItem
    {
        /// <summary>
        /// Value that identifes the item, can be UPC, PLU, SKU, etc.  Typically for CPG offers the value will be the item UPC
        /// </summary>
        public string ItemCode { get; set; }

        /// <summary>
        /// Indicates if the item was used to qualify the redemption or is a redeemed item. 
        /// True for Qualifying, False for Redeemed (example Buy One (T), Get One(F))
        /// </summary>
        public bool QualifyingFlag { get; set; }

        /// <summary>
        /// Item Price.  For qualifying items, this will equal the item price.  In the case Redeemed Items for 
        /// "Buy X, Get Y" offers, this value should reflect the true price of the item before a discount has been applied.  
        /// Example 1: Buy 2 items, get 50% off third item, the value would equal the full retail price of the third item.  
        /// Example 2: Buy 2 items, Get Third Item Free, the value would reflect the full retail price of the 'free' item, 
        /// even if the full retail price exceeds the maximum value of the offer.
        /// </summary>
        public double Price { get; set; }
    }

    public class RedeemedOffer
    {
        /// <summary>
        /// Required for all offer redemptions: Actual Savings applied to discount a sale for a qualified offer.  
        /// Will match the WalletItem discount amount for "Cents Off" offers, but will identfy the actual discount 
        /// applied for "Percentage Off" or "Free" offers.  In the case of "Free" the Redemption AMount will 
        /// reflect the value of the free item, not to exceed the max value
        /// </summary>
        public double RedemptionAmount { get; set; }

        /// <summary>
        /// Conditional (required for CPG offer redemptions)  - Array line item details related to a CPG redemption	
        /// "312546621596","Q","1.42"
        /// "849803055295","R","1.39"
        /// </summary>
        public List<RedeemedItem> RedemptionDetail { get; set; }
    }
}
