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
    public class TradeMarket : TradeBase
    {
        public static string SellMarket(string Ticker, int Quantity)
        {
            TradeMarket ts = new TradeMarket(Ticker, Quantity, eInstruction.SELL, 
                eOrderType.MARKET, eSession.NORMAL, eDuration.DAY);

            return JsonSerializer.Serialize(ts);
        }
        public static string BuyMarket(string Ticker,int Quantity)
        {
            TradeMarket ts = new TradeMarket(Ticker, Quantity, eInstruction.BUY,
                eOrderType.MARKET, eSession.NORMAL, eDuration.DAY);

            return JsonSerializer.Serialize(ts);
        }

        public static string BuyMOC(string Ticker,int Quantity)
        {
            TradeMarket ts = new TradeMarket(Ticker, Quantity, eInstruction.BUY,
                            eOrderType.MARKET_ON_CLOSE, eSession.NORMAL, eDuration.DAY);

            return JsonSerializer.Serialize(ts);
        }

        public TradeMarket(string Ticker, int Quantity, eInstruction Instruction,
            eOrderType OrderType, eSession Session, eDuration Duration)
        {

            orderType = OrderType.ToString();
            session = Session.ToString();
            duration = Duration.ToString();
   
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
