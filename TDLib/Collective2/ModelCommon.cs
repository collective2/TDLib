using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDLib.Collective2
{
    /// <summary>
    /// Common classes for Collective2 models
    /// </summary>
    public class Responsestatus
    {
        public string ErrorCode { get; set; }
    }

    public class C2symbol
    {
        public string FullSymbol { get; set; }
        public string SymbolType { get; set; }
    }
    public class Exchangesymbol
    {
        public string Symbol { get; set; }
        public string Currency { get; set; }
        public string SecurityExchange { get; set; }
        public string SecurityType { get; set; }
        public int PriceMultiplier { get; set; }
    }
}
