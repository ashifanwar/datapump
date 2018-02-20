using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODSFunction.Implementation
{
    public class Tender
    {
        /// <summary>
        /// MSP generated unique ID for the tender.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Tender Status - possible values could be listed here.
        /// </summary>
        public string Status { get; set; }

        public string ExternalTenderId { get; set; }

        /// <summary>
        /// Selected sequence for processing the Tenders of this Category
        /// </summary>
        public int Sequence { get; set; }

        /// <summary>
        /// Merchant ID current ticket is associated with.
        /// This property to support data access partition key.
        /// </summary>
        [JsonIgnore]
        public string MerchantId { get; set; }

        /// <summary>
        /// Id of WalletItem offered in this tender.
        /// </summary>
        public string WalletItemId { get; set; }

        /// <summary>
        /// User friendly name/title of the WalletItem either set by User or derived during the provisioning process (eg. Main Visa ending 4567)
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Id of embedded WalletItemType
        /// </summary>
        public string WalletItemTypeId { get; set; }

        /// <summary>
        /// Name of embedded WalletItemType
        /// </summary>
        public string WalletItemTypeName { get; set; }

        public WalletItemTypeInfo WalletItemType { get; set; }

        public IList<ProcessingDataItem> ProcessingData { get; set; }

        public IList<PresentationDataItem> PresentationData { get; set; }

        public AccountDataInternal AccountDataInternal { get; set; }


        #region Hidden properties

        [JsonIgnore]
        public string TicketId { get; set; }

        [JsonIgnore]
        public DateTime CreatedOn { get; set; }

        [JsonIgnore]
        public bool IsActive { get; set; }

        #endregion

        #region Obsolete properties

        /// <summary>
        /// The type of walletitem based on the category: Payment: Credit, debit, ach.  Loyalty: employee, other.  Offer: Discount, Inmar
        /// </summary>
        [Obsolete]
        public string Type { get; set; }

        /// <summary>
        /// WalletItem category.
        /// </summary>
        [Obsolete]
        public string Category { get; set; }

        /// <summary>
        /// Name of the wallet item type; could be POS-specific and different from what is displayed in the Wallet
        /// </summary>
        [Obsolete]
        public string NamePOS { get; set; }

        /// <summary>
        /// Compliance-approved name for use on Merchant receipts
        /// </summary>
        [Obsolete]
        public string NameReceipt { get; set; }

        /// <summary>
        /// WalletItem Issuer Name (BIMACH, Target, ChasePay)
        /// </summary>
        [Obsolete]
        public string IssuerName { get; set; }

        /// <summary>
        /// WalletItem Issuer Id
        /// </summary>
        [Obsolete]
        public string IssuerId { get; set; }

        [Obsolete]
        public string ProcessorMessageType { get; set; }

        /// <summary>
        /// MCX, Self
        /// </summary>
        [Obsolete]
        public string ProcessorId { get; set; }

        /// <summary>
        /// Information that is required on the receipt when this wallet item is used as a tender
        /// </summary>
        [Obsolete]
        public string ReceiptText { get; set; }

        /// <summary>
        /// Url for the WalletItem Image
        /// </summary>
        [Obsolete]
        public string ImageUrl { get; set; }

        /// <summary>
        /// Grab-bag of category-specific information
        /// </summary>
        [Obsolete]
        public JObject AdditionalInfo { get; set; }

        #endregion
    }

    public enum TenderStatus
    {
        Selected,
        Submitted,
        Removed,
        Revoked
    }

    public class WalletItemTypeInfo
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string NameReceipt { get; set; }
        public string NamePOS { get; set; }
        public string IssuerId { get; set; }
        public string IssuerName { get; set; }
        public string ProcessorId { get; set; }
        public string ProcessorMessageType { get; set; }
        public string ReceiptText { get; set; }
        public string Category { get; set; }
        public string Type { get; set; }
        public string ImageURL { get; set; }
        public List<string> Keywords { get; set; }
        public string ETag { get; set; }
        public JObject AdditionalInfo { get; set; }
        public string Status { get; set; }
        public string MDMVersion { get; set; }
    }

    public class AccountDataInternal
    {
        public string PanDpan { get; set; }

        public DateTime ExpirationDate { get; set; }

        public string TokenRequestorId { get; set; }

        public string Cryptogram { get; set; }

        public string ECIIndicator { get; set; }
    }

    public class ProductData
    {
        public string ProductCode { get; set; }
        public string ProductDescription { get; set; }
        public double Amount { get; set; }
        public double UnitPrice { get; set; }
        public double Quantity { get; set; }
        public string UnitOfMeasure { get; set; }
    }

    public class Account
    {
        public string PanDpan { get; set; }

        public DateTime ExpirationDate { get; set; }

        public string Track1Data { get; set; }

        public string Track2Data { get; set; }

        public string PINBlock { get; set; }

        public string CardVerificationCode { get; set; }

        public string AVSZipCode { get; set; }

        public string AVSHouseNumber { get; set; }
    }

    public class EcommerceData
    {
        public string EcomInd { get; set; }

        public string EcomGoodsInd { get; set; }

        // "1" since this is an ecomm transaction - extract payment info from the request.
        //
        public string IsEcommerceTransaction { get; set; }

        public string DestinationZipCode { get; set; }

        public string OrderNumber { get; set; }
    }

    public class CarRentalData
    {
        public string RenterName { get; set; }
        public string RentalAgreementNumber { get; set; }
        public double ExtraChargeAmount { get; set; }
        public string ExtraChargeReasons { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public DateTime RentalDateTime { get; set; }
        public string ReturnCity { get; set; }
        public string ReturnState { get; set; }
        public DateTime ReturnDateTime { get; set; }
    }

    public class LodgingData
    {
        public string MarketSpecificAuthData { get; set; }
        public string FolioNumber { get; set; }
        public string ChargeDesc { get; set; }
        public DateTime Arrival { get; set; }
        public DateTime Departure { get; set; }
        public string SaleCode { get; set; }
        public string ExtraChargesReason { get; set; }
        public double ExtraChargesAmount { get; set; }
    }
}
