using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDLib.Collective2
{

    public class GetStrategyOpenPositionsModel
    {
        public OPResult[] Results { get; set; }
        public Responsestatus ResponseStatus { get; set; }
    }


    public class OPResult
    {
        public int StrategyId { get; set; }
        public string Currency { get; set; }
        public int Quantity { get; set; }
        public DateTime OpenedDate { get; set; }
        public int AvgPx { get; set; }
        public C2symbol C2Symbol { get; set; }
        public Exchangesymbol ExchangeSymbol { get; set; }
    }



}
