using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODSFunction.Implementation
{
    public class FuelSiteUpsellOption
    {
        public string ProductCode { get; set; }
        public string ProductDescription { get; set; }
        public string ProductCategory { get; set; }
        public double UnitPrice { get; set; }
        public double MaxQuantity { get; set; }
        public string ProductImageURL { get; set; }
        public Dictionary<string, JObject> AdditionalInfo { get; set; }
    }

    public class FuelSiteDetails
    {
        public List<PumpData> PumpNumbers { get; set; }
        public bool AccessCodeEnabled { get; set; }
        public string AccessCodeLength { get; set; }
        public string AccessCode { get; set; }
        public bool PrintReceiptEnabled { get; set; }
        public double? PreAuthAmount { get; set; }
        public DateTime? LocalDateTime { get; set; }
        public List<FuelSiteUpsellOption> FuelSiteUpsellOptions { get; set; }
        public Dictionary<string, JObject> AdditionalInfo { get; set; }
    }

    public class AvailableSite
    {
        public string MCXMID { get; set; }
        public string SiteId { get; set; }
        public string StoreCode { get; set; }
        public string StoreName { get; set; }
        public string SiteDescription { get; set; }
        public string SiteControllerId { get; set; }
        public string BrandName { get; set; }
        public string SL_Address1 { get; set; }
        public string SL_Address2 { get; set; }
        public string SL_City { get; set; }
        public string SL_State { get; set; }
        public string SL_ZipCode { get; set; }
        public string MCXCategory { get; set; }
        public string SL_LogoImageURL { get; set; }
    }

    public class PumpData
    {
        public string PumpNumber { get; set; }
        public bool Available { get; set; }
    }
}
