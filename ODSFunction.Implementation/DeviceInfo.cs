using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODSFunction.Implementation
{
    public class DeviceInfo
    {
        /// <summary>
        /// MSP Unique ID for Device
        /// </summary>
        public string Id { get; set; }

        public string ExternalDeviceId { get; set; }

        public string OsType { get; set; }

        public string OsVersion { get; set; }

        public string ReputationId { get; set; }

        public string AdditionalInfo { get; set; }

        public string IPAddress { get; set; }
    }

    public class LocationInfo
    {
        /// <summary>
        /// Name of the MCXBrand that was onboarded in MDM
        /// </summary>
        public string BrandName { get; set; }

        /// <summary>
        /// MSP Unique ID for this Merchant Location joining the Ticket, (either MCXMID or StoreCode are required, 
        /// if Storecode is registered during merchant onboarding, the reverse lookup will be used to populate the MCXMID)
        /// </summary>
        public string MCXMID { get; set; }

        /// <summary>
        /// Enables brands (such as Shell to use their store code along with their brand instead of MCXMID.
        /// </summary>
        public string MCXBrandId { get; set; }

        /// <summary>
        /// Merchant's Unique ID for this Location - either MCXMID or StoreCode are required, 
        /// optionally can be provided to do reverse lookup of MCXMID, MCX MID is preferred
        /// </summary>
        public string StoreCode { get; set; }

        /// <summary>
        /// Merchant Friendly Name at MCXMID, lookup from MDM
        /// </summary>
        public string StoreName { get; set; }

        /// <summary>
        /// Location's Street Address1 from MDM for this MCXMID
        /// </summary>
        public string Address1 { get; set; }

        /// <summary>
        /// Location's Street Address2 from MDM for this MCXMID
        /// </summary>
        public string Address2 { get; set; }

        /// <summary>
        /// Location's City from MDM for this MCXMID
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Location's State from MDM for this MCXMID
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Location's Zipcode from MDM for this MCXMID
        /// </summary>
        public string Zipcode { get; set; }

        /// <summary>
        /// Location's Country from MDM for this MCXMID
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Location's primary phone number
        /// </summary>
        public string SL_Phone { get; set; }

        /// <summary>
        /// Merchant's Brand Logo Image URL
        /// </summary>
        public string ImageURL { get; set; }

        public string SiteId { get; set; }

        public string SiteDescription { get; set; }

        /// <summary>
        /// future use, Key value pairs
        /// </summary>
        public JObject AdditionalInfo { get; set; }

        public string SL_Address1 { get; set; }

        public string SL_Address2 { get; set; }

        public string SL_City { get; set; }

        public string SL_State { get; set; }

        public string SL_ZipCode { get; set; }


    }

    public class ApplicationInfo
    {
        /// <summary>
        /// Value created by MCX to identify Apps and inferred by the App's credentials.
        /// </summary>
        public string Id { get; set; }

        public string ApplicationPublisher { get; set; }

        public string ExternalAppId { get; set; }

        public string Version { get; set; }

        /// <summary>
        /// future use, Key value pairs
        /// </summary>
        public Dictionary<string, JObject> AdditionalInfo { get; set; }

    }
}
