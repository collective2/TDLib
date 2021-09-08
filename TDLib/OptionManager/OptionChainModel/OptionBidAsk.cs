using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TDLib
{
    public partial class OptionBidAsk : JsonObjectBuilder
    {
        public decimal strike { get; set; }
        public string putCall { get; set; }
        public decimal bid { get; set; }
        public decimal ask { get; set; }

        public double delta { get; set; }

        public double theta {get;set;}
        public override void LoadVariable(string Name, JsonElement Value)
        {
            //Console.WriteLine($"load variable {Name} with value {Value}");
            switch (Name)
            {
                case "putCall":
                    putCall = Value.GetString();
                    break;
                case "bid":
                    bid = Value.GetDecimal();
                    break;
                case "ask":
                    ask = Value.GetDecimal();
                    break;
                case "delta":
                    if (Value.ToString() != "NaN")
                    {
                        delta = Value.GetDouble();
                    }
                    break;
                case "theta":
                    if (Value.ToString() != "NaN")
                    {
                        theta = Value.GetDouble();
                    }
                    break;
            }
        }
    }








}
