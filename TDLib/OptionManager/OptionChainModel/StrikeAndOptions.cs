using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace TDLib
{

    public partial class StrikeAndOptions : JsonObjectBuilder
    {
        public List<OptionBidAsk> OptionDataList { get; set; } = new List<OptionBidAsk>();

        public override void LoadArray(string Name, JsonElement oEle)
        {
            foreach (var v in oEle.EnumerateArray())
            {
                switch (v.ValueKind)
                {
                    case JsonValueKind.Object:
                        OptionBidAsk od = new OptionBidAsk();
                        od.strike = Convert.ToDecimal(Name);
                        OptionDataList.Add(od);
                        od.LoadObject("", v);
                        break;
                    default:
                        throw new Exception($"expected object element, found token type {v.ValueKind}");
                }
            }
        }

    }
}
