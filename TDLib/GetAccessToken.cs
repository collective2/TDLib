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
        /*
         * Generate an access token for one or more requests. These access tokens last 30 minutes.
         */
        public string GetAccessToken()
        {
            string value = "";

            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            NameValueCollection values = new NameValueCollection();
            values.Add("grant_type", "refresh_token");
            values.Add("refresh_token", refresh_token);     // this is the 90 day key
            values.Add("client_id", ConsumerKey);           // this is API key, retrieved by logging into the developer site
            string Url = "https://api.tdameritrade.com/v1/oauth2/token";

            using (WebClient client = new WebClient())
            {
                client.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                byte[] result = client.UploadValues(Url, "POST", values);
                string ResultAuthTicket = System.Text.Encoding.UTF8.GetString(result);

                using (JsonDocument document = JsonDocument.Parse(ResultAuthTicket))
                {
                    JsonElement root = document.RootElement;
                    JsonElement accessToken = root.GetProperty("access_token");

                    value = accessToken.GetString();
                }
            }

            return value;

        }
    }
}
