using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDLib
{
    // Include properties for all trades. The specific sub classes will implement the properties.
    public partial class TradeBase
    {
        public enum eOrderType
        {
            MARKET,
            LIMIT,
            STOP,
            STOP_LIMIT,
            TRAILING_STOP,
            MARKET_ON_CLOSE,
            EXERCISE,
            TRAILING_STOP_LIMIT,
            NET_DEBIT,
            NET_CREDIT,
            NET_ZERO
        };

        public enum eSession
        {
            NORMAL,
            AM,
            PM,
            SEAMLESS
        };

        public enum eDuration
        {
            DAY,
            GOOD_TILL_CANCEL,
            FILL_OR_KILL,
        };
        public enum eOrderstrategytype
        {
            SINGLE,
            OCO,
            TRIGGER
        };

        public enum eInstruction
        {
            BUY, SELL, BUY_TO_COVER, SELL_SHORT, BUY_TO_OPEN, BUY_TO_CLOSE,
            SELL_TO_OPEN, SELL_TO_CLOSE, EXCHANGE
        }

        public enum eAssettype
        {
            EQUITY, OPTION, INDEX, MUTUAL_FUND, CASH_EQUIVALENT, FIXED_INCOME, CURRENCY
        }

    }


    public class PendingOrderLeg
    {
        public string orderLegType { get; set; }
        public int legId { get; set; }
        public LegInstrument instrument { get; set; }
        public string instruction { get; set; }
        public string positionEffect {get;set;}
        public decimal quantity { get; set; }
        
    }

    public class LegInstrument
    {
        public string assetType { get; set; }
        public string cusip { get; set; }
        public string symbol { get; set; }
        
    }

    public class Orderlegcollection
    {
        public string instruction { get; set; }
        public int quantity { get; set; }
        public Instrument instrument { get; set; }
    }

    public class Instrument
    {
        public string symbol { get; set; }
        public string assetType { get; set; }
    }
}

