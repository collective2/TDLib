using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TDLib.Collective2;

namespace TDLib.Collective2
{

    public class GetStrategyActiveOrdersModel
    {
        public AOResult[] Results { get; set; }
        public Responsestatus ResponseStatus { get; set; }
    }



    public class AOResult
    {
        public string OrderStatus { get; set; }
        public int FilledQuantity { get; set; }
        public DateTime PostedDate { get; set; }
        public int SignalType { get; set; }
        public int StrategyId { get; set; }
        public int SignalId { get; set; }
        public string OrderType { get; set; }
        public string Side { get; set; }
        public string OpenClose { get; set; }
        public int OrderQuantity { get; set; }
        public string TIF { get; set; }
        public C2symbol C2Symbol { get; set; }
        public Exchangesymbol ExchangeSymbol { get; set; }
    }

}


namespace TDLib
{
    public partial class TDConnection
    {
        public async Task<GetStrategyActiveOrdersModel> GetStrategyActiveOrders(string StrategyID)
        {
            string Url = $"https://api4.collective2.com:443/Strategies/GetStrategyActiveOrders?strategyId={StrategyID}";

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

                    GetStrategyActiveOrdersModel oModel = JsonSerializer.Deserialize<GetStrategyActiveOrdersModel>(json);

                    return oModel;

                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return null;
        }
    }
}