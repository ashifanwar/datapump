using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODSFunction.Implementation
{
    public abstract class DataItem
    {
        public string Key { get; set; }
        public object Value { get; set; }

        public DataItem(string inKey, object inValue)
        {
            Key = inKey;
            Value = inValue;
        }

        public DataItem()
        {
        }

        public override string ToString()
        {
            return $"{Key} - {Value}";
        }
    }

    public class ProvisioningDataItem : DataItem
    {
        public ProvisioningDataItem(string inKey, object inValue) : base(inKey, inValue)
        {
        }

        public ProvisioningDataItem() : base()
        {
        }
    }

    public class ProcessingDataItem : DataItem
    {
        public ProcessingDataItem(string inKey, object inValue) : base(inKey, inValue)
        {
        }

        public ProcessingDataItem() : base()
        {
        }
    }

    public class PresentationDataItem : DataItem
    {
        public PresentationDataItem(string inKey, object inValue) : base(inKey, inValue)
        {
        }

        public PresentationDataItem() : base()
        {
        }
    }
}
