using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;

namespace TDLib
{
    public partial class TDConnection 
    {

        public void PlaceTrade(string accesstoken,string jsonOrder)
        {

            string Url = $"https://api.tdameritrade.com/v1/accounts/{AppKeys.AccountNumber}/orders";

            using (WebClient client = new WebClient())
            {
                client.Headers.Add("Content-Type", "application/json");
                client.Headers.Add("Authorization", $"Bearer {accesstoken}");
                client.UploadData(Url, "POST", Encoding.ASCII.GetBytes(jsonOrder));
               
            }

            return;

        }

        // using System.Net.Http.Json;
        public async Task<string> PostTrade(string accesstoken, string jsonOrder)
        {
            string Url = $"https://api.tdameritrade.com/v1/accounts/{AppKeys.AccountNumber}/orders";

            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var postRequest = new HttpRequestMessage(HttpMethod.Post, Url)
                    {
                        Content = new StringContent(jsonOrder,Encoding.UTF8,"application/json") 
                    };

                    postRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accesstoken);

                    var postResponse = await httpClient.SendAsync(postRequest);

                    postResponse.EnsureSuccessStatusCode();

                }
            } catch(HttpRequestException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return "";
        }
    }
}
