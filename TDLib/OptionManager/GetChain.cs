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
     /// <summary>
     /// pull options of a type at a string during a time
     /// </summary>
     /// <param name="accesstoken"></param>
     /// <param name="ticker"></param>
     /// <param name="contractType"></param>
     /// <param name="strike"></param>
     /// <param name="dtFrom"></param>
     /// <param name="dtTo"></param>
     /// <returns></returns>
        public OptionChainModel GetChain(string accesstoken, string ticker,
            string contractType, decimal strike,
            DateTime dtFrom,
            DateTime dtTo
            )
        {
            string Url = $"https://api.tdameritrade.com/v1/marketdata/chains";

            using (WebClient client = new WebClient())
            {
                // client.Headers.Add("Content-Type", "application/json");
                client.Headers.Add("Authorization", $"Bearer {accesstoken}");

                client.QueryString.Add("symbol", ticker);

                client.QueryString.Add("strike", strike.ToString());

                if (contractType == "P") contractType = "PUT";
                if (contractType == "C") contractType = "CALL";

                client.QueryString.Add("contractType", contractType);

                client.QueryString.Add("fromDate", dateformat(dtFrom));
                client.QueryString.Add("toDate", dateformat(dtTo));

                var response = client.DownloadString(Url);

                OptionChainModel ocm = new OptionChainModel();

                ocm.Load(response);

                return ocm;
            }
        }

        private string dateformat(DateTime dt)
        {
            int year = dt.Year;
            int month = dt.Month;
            int day = dt.Day;

            string result = year.ToString() + "-";
            result += month < 10 ? "0" : "";
            result += month;

            result += "-";

            result += day < 10 ? "0" : "";
            result += day;

            return result;
        }


        /// <summary>
        /// Get a count of OTM puts for a date, used for locating potential credit spreads
        /// </summary>
        /// <param name="accesstoken"></param>
        /// <param name="ticker"></param>
        /// <param name="strikeCount"></param>
        /// <param name="dtFrom"></param>
        /// <param name="dtTo"></param>
        /// <returns></returns>
        public OptionChainModel GetChainOTMPuts(string accesstoken, string ticker,DateTime dtFrom,DateTime dtTo)
        {
            string Url = $"https://api.tdameritrade.com/v1/marketdata/chains";

            using (WebClient client = new WebClient())
            {
                // client.Headers.Add("Content-Type", "application/json");
                client.Headers.Add("Authorization", $"Bearer {accesstoken}");

                client.QueryString.Add("symbol", ticker);

                client.QueryString.Add("range", "OTM");

                client.QueryString.Add("contractType", "PUT");

                client.QueryString.Add("fromDate", dateformat(dtFrom));
                client.QueryString.Add("toDate", dateformat(dtTo));

                var response = client.DownloadString(Url);

                OptionChainModel ocm = new OptionChainModel();

                ocm.Load(response);

                return ocm;
            }
        }

        /// <summary>
        /// Get a count of OTM puts for a date, used for locating potential credit spreads
        /// </summary>
        /// <param name="accesstoken"></param>
        /// <param name="ticker"></param>
        /// <param name="strikeCount"></param>
        /// <param name="dtFrom"></param>
        /// <param name="dtTo"></param>
        /// <returns></returns>
        public OptionChainModel GetChainNTMPuts(string accesstoken, string ticker, DateTime dtFrom, DateTime dtTo)
        {
            string Url = $"https://api.tdameritrade.com/v1/marketdata/chains";

            using (WebClient client = new WebClient())
            {
                // client.Headers.Add("Content-Type", "application/json");
                client.Headers.Add("Authorization", $"Bearer {accesstoken}");

                client.QueryString.Add("symbol", ticker);

                //  client.QueryString.Add("strikeCount", strikeCount.ToString());

                client.QueryString.Add("range", "NTM");

                client.QueryString.Add("contractType", "PUT");

                client.QueryString.Add("fromDate", dateformat(dtFrom));
                client.QueryString.Add("toDate", dateformat(dtTo));

                var response = client.DownloadString(Url);

                OptionChainModel ocm = new OptionChainModel();

                ocm.Load(response);

                return ocm;
            }
        }

        /// <summary>
        /// pull all options for the ticker
        /// </summary>
        /// <param name="accesstoken"></param>
        /// <param name="ticker"></param>
        /// <returns></returns>
        public OptionChainModel GetChain(string accesstoken,string ticker)
           
        {
            string Url = $"https://api.tdameritrade.com/v1/marketdata/chains";

            using (WebClient client = new WebClient())
            {
               // client.Headers.Add("Content-Type", "application/json");
                client.Headers.Add("Authorization", $"Bearer {accesstoken}");

                client.QueryString.Add("symbol", ticker);

                var response = client.DownloadString(Url);

                OptionChainModel ocm = new OptionChainModel();

                ocm.Load(response);

                return ocm;
            }

            
        }


    }


}
