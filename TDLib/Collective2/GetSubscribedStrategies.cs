using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TDLib.Collective2;

namespace TDLib
{
    public partial class TDConnection
    {
        public async Task<GetSubscribedStrategiesModel> GetSubscribedStrategies()
        {
            string Url = $"https://api4.collective2.com:443/General/GetSubscribedStrategies?personId={AppKeys.Collective2PersonID}";

            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var postRequest = new HttpRequestMessage(HttpMethod.Get, Url);
 
                    postRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", AppKeys.Collective2APIKey);

                    var postResponse = await httpClient.SendAsync(postRequest);

                    postResponse.EnsureSuccessStatusCode();

                    string json = await postResponse.Content.ReadAsStringAsync();

                    GetSubscribedStrategiesModel oModel = JsonSerializer.Deserialize<GetSubscribedStrategiesModel>(json);

                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return new GetSubscribedStrategiesModel();
        }
    }
}


namespace TDLib.Collective2
{

    public class GetSubscribedStrategiesModel
    {
        public StratResult[] Results { get; set; }
        public Responsestatus ResponseStatus { get; set; }
    }

 
    public class StratResult
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int StrategyId { get; set; }
        public string StrategyName { get; set; }
        public bool IsSimulation { get; set; }
        public bool IsPaperTrade { get; set; }
        public DateTime SubscriptionDate { get; set; }
    }


   
}
