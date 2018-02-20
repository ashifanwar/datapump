using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODSFunction.Implementation
{
    public class MerchantLocation
    {
        public MerchantLocation() { }

        // ReSharper disable once UnusedParameter.Local
        public MerchantLocation(string isoValues)
        {
        }

        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostCode { get; set; }
        public string Country { get; set; }

        public string StateCodeNumeric2 { get; set; }
        public string CountyCodeNumeric3 { get; set; }
        public string CountryCodeNumeric3 { get; set; }

        public string ISOAddress
        {
            get
            {
                var stringValue = GetFieldValueFormat(Address, 23);
                stringValue += GetFieldValueFormat(City, 13);
                stringValue += GetFieldValueFormat(State, 2);
                stringValue += GetFieldValueFormat(Country, 2);

                return stringValue;
            }
            set
            {
                if (value.Length >= 23) Address = value.Substring(0, 23);
                if (value.Length >= 36) City = value.Substring(23, 13);
                if (value.Length >= 38) State = value.Substring(36, 2);
                if (value.Length >= 40) Country = value.Substring(38, 2);
            }
        }

        public string NationalPOSGeographicData
        {
            get
            {
                var stringValue = string.Empty;

                stringValue += this.StateCodeNumeric2;
                stringValue += string.IsNullOrWhiteSpace(this.CountyCodeNumeric3) ? "000" : this.CountyCodeNumeric3;
                //stringValue += this.PostCode;
                stringValue += GetFieldValueFormat(this.PostCode, 9);
                stringValue += this.CountryCodeNumeric3;

                return stringValue;
            }
            set
            {
                // length will be either 5 or 9 based on the overall length of the field (13 or 17)
                var postalCodeLength = value.Length - 8;

                if (value.Length >= 2)
                    this.StateCodeNumeric2 = value.Substring(0, 2);

                if (value.Length >= 5)
                {
                    var countyCode = value.Substring(2, 3);
                    if (countyCode != "000")
                    {
                        this.CountyCodeNumeric3 = countyCode;
                    }
                }

                if (value.Length >= postalCodeLength + 5)
                    this.PostCode = value.Substring(5, postalCodeLength);

                if (value.Length >= postalCodeLength + 8)
                    this.CountryCodeNumeric3 = value.Substring(postalCodeLength + 5, 3);
            }
        }

        public string OriginatorStoreId { get; set; }

        private string GetFieldValueFormat(string fieldValue, int length)
        {
            var fieldValueFormat = string.IsNullOrEmpty(fieldValue) ? string.Empty : fieldValue;
            if (fieldValueFormat.Length > length)
            {
                fieldValueFormat = fieldValueFormat.Substring(0, length);
            }

            return fieldValueFormat.PadRight(length, ' ');
        }
    }
}
