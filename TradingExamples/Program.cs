using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDLib;

namespace TradingExamples
{
    /// <summary>
    /// Sample code to show how to place trades.
    /// The methodology for trading is two steps:
    /// 1. Generate the model used for the trade. 
    /// 2. Call the API to place the trade.
    /// 
    /// The reason for breaking this into two steps is to be able to manage the complexity of the API model for ordering and separate
    /// that complexity from the actual trade. The API takes a JSON body containing the order, so we first build that json body and then
    /// we call the API.
    /// 
    /// You could, of course, wrap building and executing into a single call but I felt that the separation of tasks made it more clear and separated 
    /// the funcitonality
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            TDConnection oTDA = new TDConnection();

            /*
             * Get an access token. This is good for 30 minutes
             */
            string accesstoken = oTDA.GetAccessToken();

            /*
             * Buy 1 share of SPY at market
             */
            string jsonOrder = TradeMarket.BuyMarket("SPY", 1);     // prepare the order
            oTDA.PlaceTrade(accesstoken, jsonOrder);                // place the trade
            /*
             * Sell 1 share of SPY at market. If you are not already long then this will open a short; there is no
             * distinction in the API between being long or short, you buy or you sell. TDA knows that you are opening or closing
             * based on whether you have a position or not
             */
            jsonOrder = TradeMarket.SellMarket("SPY", 1);           // prepare the order
            oTDA.PlaceTrade(accesstoken, jsonOrder);                // place the trade

            /*
             * Buy 1 share of SPY at limit good for the day
             */
            jsonOrder = TradeLimit.BuyLimit("SPY", 1, 300.88M);      // prepare the order
            oTDA.PlaceTrade(accesstoken, jsonOrder);                 // place the trade
            
            /*
             * Buy 1 share of SPY at limit Good Till Cancelled
             */
            jsonOrder = TradeLimit.BuyLimitGTC("SPY", 1, 300.34M);   // prepare the order
            oTDA.PlaceTrade(accesstoken, jsonOrder);                 // place the trade

            /*
             * Sell 1 share of SPY limit order
             */
            jsonOrder = TradeLimit.SellLimit("SPY", 1, 300.88M);     // prepare the order
            oTDA.PlaceTrade(accesstoken, jsonOrder);                 // place the trade

            /*
             * Sell 1 share of SPY at limit Good Till Cancelled
             */
            jsonOrder = TradeLimit.SellLimitGTC("SPY", 1, 300.34M);  // prepare the order
            oTDA.PlaceTrade(accesstoken, jsonOrder);                 // place the trade

            /*
             * Place a One Triggers Another order. This type of order is very useful for building a ladder of trades
             * This is a buy then sell order. Once the buy is filled a sell order is placed 40 cents higher
             */
            jsonOrder = TradeOTA.BuyThenSell("SPY", 1, 300.0M, 40); // prepare the order. Sell 40 cents higher than the buy
            oTDA.PlaceTrade(accesstoken, jsonOrder);                // place the trade

            /*
             * This is a sell, then buy order. One the sell has filled a buy order is placed
             */
            jsonOrder = TradeOTA.SellThenBuy("SPY", 1, 300.0M, 40); // prepare the order. buy 40 cents lower than the sell order
            oTDA.PlaceTrade(accesstoken, jsonOrder);                // place the trade

        }
    }
}
