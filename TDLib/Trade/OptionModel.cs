using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDLib.OptionModel
{

    public class RootObject
    {
        public enum eAssettype
        {
            EQUITY, OPTION, INDEX, MUTUAL_FUND, CASH_EQUIVALENT, FIXED_INCOME, CURRENCY
        }

        public enum eType
        {
            VANILLA, BINARY, BARRIER
        }

        public enum ePutCall
        {
            PUT, CALL
        }

        public enum eCurrencytype {
            USD,
            CAD,
            EUR,
            JPY
            }

        public string assetType { get; set; }
        public string cusip { get; set; }
        public string symbol { get; set; }
        public string description { get; set; }
        public string type { get; set; }
        public string putCall { get; set; }
        public string underlyingSymbol { get; set; }
        public int optionMultiplier { get; set; }
        public Optiondeliverables optionDeliverables { get; set; }
    }



    public class Optiondeliverables
    {
        public string type { get; set; }
        public Xml xml { get; set; }
        public Items items { get; set; }
    }

    public class Xml
    {
        public string name { get; set; }
        public bool wrapped { get; set; }
    }

    public class Items
    {
        public string type { get; set; }
        public Properties properties { get; set; }
    }

    public class Properties
    {
        public Symbol1 symbol { get; set; }
        public Deliverableunits deliverableUnits { get; set; }
        public string currencyType { get; set; }
        public string assetType { get; set; }
    }

    public class Symbol1
    {
        public string type { get; set; }
    }

    public class Deliverableunits
    {
        public string type { get; set; }
        public string format { get; set; }
    }

}
