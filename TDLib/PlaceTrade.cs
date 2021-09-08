using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TDLib
{
    public partial class TDConnection 
    {

        public void PlaceTrade(string accesstoken,string jsonOrder)
        {

            string Url = $"https://api.tdameritrade.com/v1/accounts/{AccountNumber}/orders";

            using (WebClient client = new WebClient())
            {
                client.Headers.Add("Content-Type", "application/json");
                client.Headers.Add("Authorization", $"Bearer {accesstoken}");
                client.UploadData(Url, "POST", Encoding.ASCII.GetBytes(jsonOrder));
               
            }

            return;

        }
    }
}
