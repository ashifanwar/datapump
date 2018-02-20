using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODSFunction.Implementation
{
    public class OriginalTenderAuthData
    {
        public string TenderAuthId { get; set; }
        public string MCXMID { get; set; }
        public string StoreCode { get; set; }
        public string TerminalID { get; set; }
        public string RetrievalReferenceNumber { get; set; }
        public DateTime LocalDateTime { get; set; }

        public string ApprovalCode { get; set; }

        public string OriginalDataISOField
        {
            get
            {
                // if none of these fields have been valued, return null (so that 
                // this won't get populated on ISO messages unexpectedly)
                if (string.IsNullOrEmpty(this.SystemsTraceAuditNumber) &&
                    string.IsNullOrEmpty(this.AcquiringIdCode) &&
                    string.IsNullOrEmpty(this.ForwardingIdCode) &&
                    this.TransmissionDate == DateTime.MinValue)
                {
                    return null;
                }

                var stringValue = string.Empty;

                stringValue += GetFieldValueFormat(this.MessageType, 4);
                stringValue += GetFieldValueFormat(this.SystemsTraceAuditNumber, 6);
                stringValue += GetFieldValueFormat(this.TransmissionDate.ToString("MMddHHmmss"), 10);
                stringValue += GetFieldValueFormat(this.AcquiringIdCode, 11);
                stringValue += GetFieldValueFormat(this.ForwardingIdCode, 11);

                return stringValue;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    if (value.Length >= 4) MessageType = value.Substring(0, 4);
                    if (value.Length >= 10) SystemsTraceAuditNumber = value.Substring(4, 6);
                    if (value.Length >= 31) AcquiringIdCode = value.Substring(20, 11);
                    if (value.Length >= 42) ForwardingIdCode = value.Substring(31, 11);
                }
            }
        }


        public string MessageType { get; set; }
        public string SystemsTraceAuditNumber { get; set; }
        public string AcquiringIdCode { get; set; }
        public string ForwardingIdCode { get; set; }
        public DateTime TransmissionDate { get; set; }

        private string GetFieldValueFormat(string fieldValue, int length)
        {
            var fieldValueFormat = fieldValue;
            if (string.IsNullOrEmpty(fieldValueFormat))
            {
                fieldValueFormat = string.Empty;
            }
            else
            {
                if (fieldValueFormat.Length > length)
                {
                    fieldValueFormat = fieldValueFormat.Substring(0, length);
                }
            }

            return fieldValueFormat.PadLeft(length, '0');
        }
    }
}
