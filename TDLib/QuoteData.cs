using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Services;
using System.Text;
using System.Threading.Tasks;

namespace TDLib
{
    public class QuoteData
    {
        public string assetType { get; set; }
        public string symbol { get; set; }
        public decimal lastPrice { get; set; }
        public int totalVolume { get; set; }
        public decimal openPrice { get; set; }
        public decimal closePrice { get; set; }
        public decimal highPrice { get; set; }
        public decimal lowPrice { get; set; }

    }
}
