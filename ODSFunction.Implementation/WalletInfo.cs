using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODSFunction.Implementation
{
    public class WalletInfo
    {
        /// <summary>
        /// Wallet associated with this transaction
        /// </summary>
        public string Id { get; set; }

        public string WalletProviderId { get; set; }

        public string WalletProviderName { get; set; }

        /// <summary>
        /// Wallet Provider ID.
        /// </summary>
        public string ExternalWalletId { get; set; }

        /// <summary>
        /// Public profile of the Wallet - could be stored at MCX in future or provided dynamically from Wallet Provider
        /// </summary>
        public JObject AdditionalInfo { get; set; }

        /// <summary>
        /// System provided transaction reference key, such as from Chase Pay API 
        /// parsed from Chase pairing.
        /// </summary>
        public string TransactionReferenceKey { get; set; }

        /// <summary>
        /// ID of the user associated with this wallet
        /// </summary>
        public string UserId { get; set; }

        #region Storage model required

        [JsonIgnore]
        public string TicketId { get; set; }
        [JsonIgnore]
        public string MerchantId { get; set; }

        #endregion Storage model required
    }
}
