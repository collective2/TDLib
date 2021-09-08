using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDLib
{
    // Include properties for all trades
    public partial class TradeBase
    {
        public string session { get; set; }
        public string duration { get; set; }
        public string orderType { get; set; }
        public string orderStrategyType { get; set; }
        public Orderlegcollection[] orderLegCollection { get; set; }
    }

}

