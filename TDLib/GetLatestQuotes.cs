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
        public List<QuoteData> GetLatestQuotes(string tickerList, string accesstoken)
        {
            List<QuoteData> QuoteDataList = new List<QuoteData>();

            // Handle null ticker list
            if (tickerList == "") return QuoteDataList;

            /*
             * Convert the ticker list into a list of strings
             */
            string[] TickerArray = tickerList.Split(",".ToCharArray());

            /*
             * Get 100 at a time to ensure that we don't max out the api
             */
            for (int i = 0; i < TickerArray.Length; i += 100)
            {
                // build a ticker list
                string tl = "";
                string comma = "";
                for (int j = 0; j < 100 && j + i < TickerArray.Length; j++)
                {
                    tl += comma + TickerArray[i + j];
                    comma = ",";
                }

                /*
                 * Get these quotes
                 */
                List<QuoteData> qd = Get100Quotes(tl, accesstoken);
                QuoteDataList.AddRange(qd);

            }


            return QuoteDataList;
        }

        private List<QuoteData> Get100Quotes(string tickerList, string accesstoken)
        {
            List<QuoteData> QuoteDataList;

            string url = $"https://api.tdameritrade.com/v1/marketdata/quotes?apikey={ConsumerKey}&symbol={tickerList}";

            using (WebClient client = new WebClient())
            {
                client.Headers.Add("Authorization", $"Bearer {accesstoken}");
                try
                {
                    byte[] result = client.DownloadData(url);
                    string Result = System.Text.Encoding.UTF8.GetString(result);

                    QuoteDataList = GetQuoteDataList(Result);

                }
                catch (WebException ex)
                {
                    /*
                     * Probably hit throttle limit of 120 a second. need to back off
                     */
                    return null;
                }
            }

            return QuoteDataList;

        }
    }
}
