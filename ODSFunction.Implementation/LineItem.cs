using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODSFunction.Implementation
{
    public class LineItem
    {
        public string ProductCode { get; set; }
        public string ProductCodeType { get; set; }
        public string ProductDescription { get; set; }
        public string ProductCategory { get; set; }
        public double UnitPrice { get; set; }
        public string UnitOfMeasure { get; set; }
        public double Quantity { get; set; }
        public double Amount { get; set; }
        public string AmountTypeDescriptor { get; set; }
        public bool TippableFlag { get; set; }
        public bool DisplayInApp { get; set; }
        public string Id { get; set; }
        public string CouponSource { get; set; }
        public string MCXCouponId { get; set; }
        public string MerchantCouponId { get; set; }

        public List<string> CouponValidatingUPCs { get; set; }
        public JObject AdditionalInfo { get; set; }
    }
}
