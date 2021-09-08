using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDLib.MutualFundModel
{

    public class RootObject
    {
        public enum eAssettype
        {
            EQUITY, OPTION, INDEX, MUTUAL_FUND, CASH_EQUIVALENT, FIXED_INCOME, CURRENCY
        }

        public enum eType
        {
            NOT_APPLICABLE, OPEN_END_NON_TAXABLE,OPEN_END_TAXABLE,NO_LOAD_NON_TAXABLE,NO_LOAD_TAXABLE
        }
        public string assetType { get; set; }
        public string cusip { get; set; }
        public string symbol { get; set; }
        public string description { get; set; }
        public string type { get; set; }
    }




}
