using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TDLib
{
    public partial class TDConnection
    {
        public List<Candle> GetDailyQuotes(string ticker,string accesstoken,int daysback)
        {

            ticker = ticker.ToUpper();

            List<Candle> CandleList = new List<Candle>();

            DateTime epoch = new DateTime(1970, 1, 1);

            var startms = (DateTime.Today.AddDays(-daysback) - epoch).TotalMilliseconds;
            var endms = (DateTime.Today.AddDays(1) - epoch).TotalMilliseconds;

            string url = $"https://api.tdameritrade.com/v1/marketdata/{ticker}/pricehistory?apikey={ConsumerKey}&periodType=month&frequencyType=daily&frequency=1&startDate={startms}&endDate={endms}";

            using (WebClient client = new WebClient())
            {
                client.Headers.Add("Authorization", $"Bearer {accesstoken}");
                try
                {
                    byte[] result = client.DownloadData(url);
                    string ResultAuthTicket = System.Text.Encoding.UTF8.GetString(result);

                    CandleList = GetCandleList(ResultAuthTicket);

                } catch (WebException ex)
                {
                    /*
                     * Probably hit throttle limit of 120 a second. need to back off
                     */
                    return null;

                }
   
            }

            return CandleList;
        }
    }
}
