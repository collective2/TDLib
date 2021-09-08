using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TDLib.OptionModel;

namespace TDLib
{
    public partial class OptionManager : TDConnection
    {
        public OptionSpreadModel GetSpread(string accesstoken, 
            string ticker,decimal interval,string contractType,decimal? eitherStrike = null)
        {
            string Url = $"https://api.tdameritrade.com/v1/marketdata/chains";

            using (WebClient client = new WebClient())
            {
                // client.Headers.Add("Content-Type", "application/json");
                client.Headers.Add("Authorization", $"Bearer {accesstoken}");

                client.QueryString.Add("symbol", ticker);
                /*
                 * use the strike price to pull options where either leg is the specified price
                 */
                if (eitherStrike != null)
                {
                    client.QueryString.Add("strike", eitherStrike.ToString());
                }

                client.QueryString.Add("strategy", "VERTICAL");
                client.QueryString.Add("contractType", contractType);
                client.QueryString.Add("interval", interval.ToString());

                var response = client.DownloadString(Url);

                OptionSpreadModel oSpread = JsonSerializer.Deserialize<OptionSpreadModel>(response);

                return oSpread;
            }
        }

    }


}
