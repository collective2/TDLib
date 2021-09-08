using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TDLib
{
    /// <summary>
    /// This is a class just used to do trades for a stock. It only generates the JSON needed
    /// without includings other fields or nulls
    /// </summary>
    public class TradeLimit : TradeBase
    {
        // when trading a limit you have to have a price field. This isn't in the base
        // because it would be sent as 0, which causes market orders to fail.
        // the trade sub classes contain fields that they will need for the order
        public decimal price { get; set; }

        public static string SellLimitGTC(string Ticker, int Quantity, decimal price)
        {
            TradeLimit ts = new TradeLimit(Ticker, Quantity, eInstruction.SELL,
                eOrderType.LIMIT, eSession.NORMAL, eDuration.GOOD_TILL_CANCEL, price);

            return JsonSerializer.Serialize(ts);
        }
        public static string SellLimit(string Ticker, int Quantity, decimal price)
        {
            TradeLimit ts = new TradeLimit(Ticker, Quantity, eInstruction.SELL,
                eOrderType.LIMIT, eSession.NORMAL, eDuration.DAY,price);

            return JsonSerializer.Serialize(ts);
        }

        public static string BuyLimitGTC(string Ticker, int Quantity, decimal price)
        {
            TradeLimit ts = new TradeLimit(Ticker, Quantity, eInstruction.BUY,
                eOrderType.LIMIT, eSession.NORMAL, eDuration.GOOD_TILL_CANCEL, price);

            return JsonSerializer.Serialize(ts);
        }
        public static string BuyLimit(string Ticker, int Quantity, decimal price)
        {
            TradeLimit ts = new TradeLimit(Ticker, Quantity, eInstruction.BUY,
                eOrderType.LIMIT, eSession.NORMAL, eDuration.DAY, price);

            return JsonSerializer.Serialize(ts);
        }   

        public TradeLimit(string Ticker, int Quantity, eInstruction Instruction,
            eOrderType OrderType, eSession Session, eDuration Duration, decimal Price)
        {

            orderType = OrderType.ToString();
            session = Session.ToString();
            duration = Duration.ToString();
            price = Price;
   
            orderStrategyType = eOrderstrategytype.SINGLE.ToString();
            orderLegCollection = new Orderlegcollection[1];
            orderLegCollection[0] = new Orderlegcollection();
            orderLegCollection[0].instruction = Instruction.ToString();
            orderLegCollection[0].quantity = Quantity;
            orderLegCollection[0].instrument = new Instrument();
            orderLegCollection[0].instrument.assetType = eAssettype.EQUITY.ToString();
            orderLegCollection[0].instrument.symbol = Ticker;
          
        }
 
    }
}
