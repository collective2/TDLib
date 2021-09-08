using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TDLib
{
    /// <summary>
    /// This is a class just used to do trades for a stock. It only generates the JSON needed
    /// without includings other fields or nulls
    /// </summary>
    public class TradeOTA : TradeBase
    {
        // when trading a limit you have to have a price field. This isn't in the base
        // because it would be sent as 0, which causes market orders to fail.
        // the trade sub classes contain fields that they will need for the order
        public decimal price { get; set; }

        public TradeLimit[] childOrderStrategies { get; set; }

        public static string SellThenBuy(string Ticker, int Quantity, decimal SellPrice, int PennyDelta)
        {
            decimal BuyPrice = SellPrice - ((decimal)PennyDelta / 100M);
            
            return SellThenBuy(Ticker, Quantity, SellPrice, BuyPrice);

        }
        public static string SellThenBuy(string Ticker, int Quantity, decimal SellPrice, decimal BuyPrice)
        {
            string template = @"{
  ""orderType"": ""LIMIT"",
  ""session"": ""NORMAL"",
  ""price"": ""{firstprice}"",
  ""duration"": ""DAY"",
  ""orderStrategyType"": ""TRIGGER"",
  ""orderLegCollection"": [
    {
      ""instruction"": ""SELL"",
      ""quantity"": {quantity},
      ""instrument"": {
        ""symbol"": ""{ticker}"",
        ""assetType"": ""EQUITY""
      }
     }
  ],
  ""childOrderStrategies"": [
    {
      ""orderType"": ""LIMIT"",
      ""session"": ""NORMAL"",
      ""price"": ""{secondprice}"",
      ""duration"": ""DAY"",
      ""orderStrategyType"": ""SINGLE"",
      ""orderLegCollection"": [
        {
         ""instruction"": ""BUY"",
          ""quantity"": {quantity},
          ""instrument"": {
            ""symbol"": ""{ticker}"",
            ""assetType"": ""EQUITY""
          }
        }
      ]
    }
  ]
}
 
";
            template = template.Replace("{ticker}", Ticker);
            template = template.Replace("{firstprice}", SellPrice.ToString());
            template = template.Replace("{quantity}", Quantity.ToString());
            template = template.Replace("{secondprice}", BuyPrice.ToString());

            return template;
        }
        public static string BuyThenSell(string Ticker, int Quantity, decimal FirstPrice, int PennyDelta)
        {
            decimal SecondPrice = FirstPrice + ((decimal)PennyDelta / 100M);
            return BuyThenSell(Ticker, Quantity, FirstPrice, SecondPrice);
        }


        public static string BuyThenSell(string Ticker, int Quantity,decimal FirstPrice,decimal SecondPrice)
        {

            string template = @"{
  ""orderType"": ""LIMIT"",
  ""session"": ""NORMAL"",
  ""price"": ""{firstprice}"",
  ""duration"": ""DAY"",
  ""orderStrategyType"": ""TRIGGER"",
  ""orderLegCollection"": [
    {
      ""instruction"": ""BUY"",
      ""quantity"": {quantity},
      ""instrument"": {
        ""symbol"": ""{ticker}"",
        ""assetType"": ""EQUITY""
      }
     }
  ],
  ""childOrderStrategies"": [
    {
      ""orderType"": ""LIMIT"",
      ""session"": ""NORMAL"",
      ""price"": ""{secondprice}"",
      ""duration"": ""DAY"",
      ""orderStrategyType"": ""SINGLE"",
      ""orderLegCollection"": [
        {
         ""instruction"": ""SELL"",
          ""quantity"": {quantity},
          ""instrument"": {
            ""symbol"": ""{ticker}"",
            ""assetType"": ""EQUITY""
          }
        }
      ]
    }
  ]
}
 
";
            template = template.Replace("{ticker}", Ticker);
           template =  template.Replace("{firstprice}", FirstPrice.ToString());
           template = template.Replace("{quantity}", Quantity.ToString());
            template = template.Replace("{secondprice}", SecondPrice.ToString());

            return template;
        }

        public TradeOTA(string Ticker, int Quantity, eInstruction FirstAction, decimal FirstPrice, decimal SecondPrice)
        {
            orderType = eOrderType.LIMIT.ToString();
            session = eSession.NORMAL.ToString();
            duration = eDuration.DAY.ToString();
            price = FirstPrice;

            eInstruction FirstOrder = FirstAction;
            eInstruction SecondOrder = FirstAction == eInstruction.BUY ? eInstruction.SELL : eInstruction.BUY;

            orderStrategyType = eOrderstrategytype.TRIGGER.ToString(); 
            orderLegCollection = new Orderlegcollection[1];
            orderLegCollection[0] = new Orderlegcollection();
            orderLegCollection[0].instruction = FirstOrder.ToString();
            orderLegCollection[0].quantity = Quantity;
            orderLegCollection[0].instrument = new Instrument();
            orderLegCollection[0].instrument.assetType = eAssettype.EQUITY.ToString();
            orderLegCollection[0].instrument.symbol = Ticker;

            childOrderStrategies = new TradeLimit[1];

            childOrderStrategies[0]
                = new TradeLimit(Ticker, Quantity, SecondOrder, 
                eOrderType.LIMIT, eSession.NORMAL, eDuration.DAY, SecondPrice);           

        }
 
    }
}
