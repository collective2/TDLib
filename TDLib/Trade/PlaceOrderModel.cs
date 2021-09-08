using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TDLib.PlaceOrderModel
{

    public class Rootobject
    {
        public enum eSession
        {
            NORMAL,
            AM ,
            PM ,
            SEAMLESS 
        };

        public enum eDuraction
        {
            DAY,
            GOOD_TILL_CANCEL ,
            FILL_OR_KILL ,
        };

        public enum eOrderType { 
            MARKET ,
            LIMIT , 
            STOP , 
            STOP_LIMIT ,
            TRAILING_STOP ,
            MARKET_ON_CLOSE , 
            EXERCISE ,
            TRAILING_STOP_LIMIT ,
            NET_DEBIT ,
            NET_CREDIT ,
            NET_ZERO 
        };

        public enum eOrderstrategytype
        {
          SINGLE ,
          OCO , 
          TRIGGER 
        };

        public enum eComplexorderstrategytype 
        { 
             NONE ,
             COVERED  ,
             VERTICAL ,
             BACK_RATIO  ,
             CALENDAR  ,
             DIAGONAL  ,
             STRADDLE  ,
             STRANGLE  ,
             COLLAR_SYNTHETIC  ,
             BUTTERFLY  ,
             COND ,
             IRON_COND ,
             VERTICAL_ROLL  ,
             COLLAR_WITH_STOCK  ,
             DOUBLE_DIAGONAL  ,
             UNBALANCED_BUTTERFLY  ,
             UNBALANCED_COND  ,
             UNBALANCED_IRON_COND  ,
             UNBALANCED_VERTICAL_ROLL 
    };

        public enum eRequesteddestination
        {

            INET,
            ECN_ARCA            ,
            CBOE             , 
            AMEX             ,
            PHLX, 
            ISE             , 
            BOX             , 
            NYSE             , 
            NASDAQ, 
            BATS             ,
            C2             ,
            AUTO
        };

        public enum eStoppricelinkbasis
        {
            MANUAL ,
            BASE ,
            TRIGGER ,
            LAST ,
            BID ,
            ASK ,
            ASK_BID ,
            MARK ,
            AVERAGE 
        };


        public enum eStoppricelinktype
        {
          VALUE ,
          PERCENT ,
          TICK 
        };

        public enum  eStoptype
        {
            STANDARD ,
            BID , 
            ASK , 
            LAST ,
            MARK 
        };

        public enum ePricelinkbasis
        {
            MANUAL  , 
            BASE , 
            TRIGGER ,
            LAST ,
            BID ,  
            ASK , 
            ASK_BID ,
            MARK ,
            AVERAGE 
        };

        public enum ePricelinktype
        {
            VALUE , 
            PERCENT , 
            TICK 
        }


        public enum eTaxlotmethod
        {
            FIFO , 
            LIFO , 
            HIGH_COST , 
            LOW_COST , 
            AVERAGE_COST , 
            SPECIFIC_LOT ,

        }

        public enum eOrderlegtype
        {
            EQUITY, OPTION, INDEX, MUTUAL_FUND, CASH_EQUIVALENT, FIXED_INCOME, CURRENCY,
        }

        public enum eAssettype
        {
            EQUITY, OPTION, INDEX, MUTUAL_FUND, CASH_EQUIVALENT, FIXED_INCOME, CURRENCY
        }


        public enum eInstruction
        {
            BUY, SELL, BUY_TO_COVER, SELL_SHORT, BUY_TO_OPEN, BUY_TO_CLOSE,
            SELL_TO_OPEN, SELL_TO_CLOSE, EXCHANGE
        }


        public enum ePositioneffect
        {
            OPENING, CLOSING, AUTOMATIC
        }


        public enum eQuantitytype
        {
            ALL_SHARES, DOLLARS, SHARES
        }
        public enum eSpecialinstruction
        {
            ALL_OR_NONE, DO_NOT_REDUCE, ALL_OR_NONE_DO_NOT_REDUCE
        }

        public enum eStatus
        {
            AWAITING_PARENT_ORDER
                    , AWAITING_MANUAL_REVIEW
                    , ACCEPTED
                    , AWAITING_UR_OUT
                    , PENDING_ACTIVATION
                    , QUEUED
                    , WORKING
                    , REJECTED
                    , PENDING_CANCEL
                    , CANCELED
                    , PENDING_REPLACE
                    , REPLACED
                    , FILLED
                    , EXPIRED

        }

        public enum eActivitytype
        {
            EXECUTION,
            ORDER_ACTION
        }

        public static void Test()
        {
            Rootobject r = new Rootobject();
            r.orderType = eOrderType.MARKET.ToString();
            r.session = eSession.NORMAL.ToString();
            r.duration = eDuraction.DAY.ToString();
            r.orderStrategyType = eOrderstrategytype.SINGLE.ToString();

            string x = JsonSerializer.Serialize(r);


         
        }


        public string session { get; set; }
        public string duration { get; set; }
        public string orderType { get; set; }
        public Canceltime cancelTime { get; set; }
        public string orderStrategyType { get; set; }
        public string complexOrderStrategyType { get; set; }
        public double quantity { get; set; }
        public double filledQuantity { get; set; }
        public double remainingQuantity { get; set; }
        public string requestedDestination { get; set; }
        public string destinationLinkName { get; set; }
        public DateTime releaseTime { get; set; }
        public double stopPrice { get; set; }
        public string stopPriceLinkBasis { get; set; }
        public string stopPriceLinkType { get; set; }
        public double stopPriceOffset { get; set; }
        public string stopType { get; set; }
        public string priceLinkBasis { get; set; }
        public string priceLinkType { get; set; }
        public double price { get; set; }
        public string taxLotMethod { get; set; }
        public OrderLeg[] orderLegCollection { get; set; }
        public double activationPrice { get; set; }
        public string specialInstruction { get; set; }
        public long orderId { get; set; }
        public bool cancelable { get; set; }
        public bool editable { get; set; }
        public string status { get; set; }
        public DateTime enteredTime { get; set; }
        public DateTime closeTime { get; set; }
        public long accountId { get; set; }
        public Orderactivitycollection orderActivityCollection { get; set; }
        public Replacingordercollection replacingOrderCollection { get; set; }
        public Childorderstrategies childOrderStrategies { get; set; }
        public string statusDescription { get; set; }
    }

    public class Canceltime
    {
        public string type { get; set; }
        public Properties properties { get; set; }
    }

    public class Properties
    {
        public Date date { get; set; }
        public Shortformat shortFormat { get; set; }
    }

    public class Date
    {
        public string type { get; set; }
    }

    public class Shortformat
    {
        public string type { get; set; }
        public bool _default { get; set; }
    }
       
   

    public class OrderLeg
    {
        public string orderLegType { get; set; }
        public long legId { get; set; }
        public Instrument instrument { get; set; }
        public string instruction { get; set; }
        public string positionEffect { get; set; }
        public double quantity { get; set; }
        public string quantityType { get; set; }
    }

 
    public class Instrument
    {
        public string assetType { get; set; }
        public string cusip { get; set; }
        public string symbol { get; set; }
        public string description { get; set; }
    }

    public class Orderactivitycollection
    {
        public string type { get; set; }
        public Xml1 xml { get; set; }
        public Items1 items { get; set; }
    }

    public class Xml1
    {
        public string name { get; set; }
        public bool wrapped { get; set; }
    }

    public class Items1
    {
        public string type { get; set; }
        public string discriminator { get; set; }
        public Properties3 properties { get; set; }
    }

    public class Properties3
    {
        public string activityType { get; set; }
    }



    public class Replacingordercollection
    {
        public string type { get; set; }
        public Xml2 xml { get; set; }
    }

    public class Xml2
    {
        public string name { get; set; }
        public bool wrapped { get; set; }
    }

    public class Childorderstrategies
    {
        public string type { get; set; }
        public Xml3 xml { get; set; }
    }

    public class Xml3
    {
        public string name { get; set; }
        public bool wrapped { get; set; }
    }

}
