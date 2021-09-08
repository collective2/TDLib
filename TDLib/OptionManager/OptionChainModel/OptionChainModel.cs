using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace TDLib
{
    public partial class OptionChainModel : JsonObjectBuilder
    {
        public string symbol { get; set; }
        public ExpirationDateMap putExpDateMap { get; set; }
        public ExpirationDateMap callExpDateMap { get; set; }

        public override void LoadObject(string Name, JsonElement oEle)
        {
            /*
             * Is this one of our variables?
             */
            if (Name == "putExpDateMap")
            {
                putExpDateMap = new ExpirationDateMap();
                putExpDateMap.LoadObject("", oEle);
            }

            if (Name == "callExpDateMap")
            {
                callExpDateMap = new ExpirationDateMap();
                callExpDateMap.LoadObject("", oEle);
            }

            //  Console.WriteLine("loading object");
            base.LoadObject(Name, oEle);
        }
        public override void LoadVariable(string Name, JsonElement Value)
        {
            //Console.WriteLine($"load variable {Name}");
            switch (Name)
            {
                case "symbol":
                    symbol = Value.GetString();
                    break;
            }
        }

        public OptionBidAsk FindOption(decimal strike,string contract)
        {
            if (contract == "CALL")
            {
                foreach (var v in callExpDateMap.DateAndStrikeList)
                {
                    foreach (var y in v.strike.OptionDataList)
                    {
                        if (y.putCall == contract && y.strike == strike) return y;
                    }
                }
            } else
            {
                foreach (var v in putExpDateMap.DateAndStrikeList)
                {
                    foreach (var y in v.strike.OptionDataList)
                    {
                        if (y.putCall == contract && y.strike == strike) return y;
                    }
                }
            }

            return null;
        }
    }
}
