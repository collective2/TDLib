using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TDLib.Collective2;
using ServiceStack;

namespace TDLib.Collective2
{
    [Api]
    [Route("/Strategies/GetStrategyActiveOrders", "GET", Summary = @"Request the open orders for the strategy", Notes = "Non-paginated endpoint")]
    public class GetStrategyActiveOrders : IGet, IReturn<GetStrategyActiveOrdersResponse>
    {
        [ApiMember(Description = @"The Strategy ID", IsRequired = true)]
        public long? StrategyId { get; set; }


        [ApiMember(Description = @"(Optional) AssetClass filter. e.g. 'stock', 'option', 'future', 'forex', 'crypto'")]
        public string AssetClass { get; set; }
    }

    public class GetStrategyActiveOrdersResponse: ResponseBase<AOResult>
    {
    }



    public class AOResult
    {
        [ApiMember(Description = "BrokerId")]
        public long BrokerId { get; set; }


        [ApiMember(Description = "'A' = PendingNew, '0' = Working, '1' = Partially filled, '2' = Filled, '4' = Canceled, '5' = Replaced, '6' = Pending Cancel, '8' = Rejected, 'C' = Expired, 'E' = Pending Replace")]
        public char OrderStatus { get; set; }


        [ApiMember(Description = "The quantity filled")]
        public decimal FilledQuantity { get; set; }


        [ApiMember(Description = "The average fill price, if FilledQuantity > 0")]
        public decimal AvgFillPrice { get; set; }


        [ApiMember(Description = "UTC DateTime when the order was posted")]
        public DateTime PostedDate { get; set; }


        [ApiMember(Description = "The type of signal. 1 = StrategySignal, 4 = ManualSignal, 5 = StrategySignalManualOverride, 6 = AutoStopLoss")]
        public int SignalType { get; set; }


        [ApiMember(Description = "The OrderId. Not needed for Signal endpoints because this only has meaning in a Autotrade context")]
        public string OrderId { get; set; }


        [ApiMember(Description = "The C2 StrategyId", IsRequired = true)]
        public long StrategyId { get; set; }


        [ApiMember(Description = "The C2 SignalId")]
        public long SignalId { get; set; }


		[ApiMember(Description = "'1' = Market, '2' = Limit, '3' = Stop", IsRequired = true)]
        public char OrderType { get; set; }


        [ApiMember(Description = "'1' = Buy, '2' = Sell", IsRequired = true)]
		public char Side { get; set; }


		[ApiMember(Description = "'O' = Open, 'C' = Close", IsRequired = true)]
		public char OpenClose { get; set; }


		[ApiMember(Description = "The order quantity", IsRequired = true)]
		public decimal OrderQuantity { get; set; }


		[ApiMember(Description = "The C2-formatted Limit Price")]
		public decimal Limit { get; set; }


		[ApiMember(Description = "The C2-formatted Stop Price")]
		public decimal Stop { get; set; }


		[ApiMember(Description = "The time in force. 0 = Day, 1 = Good Till Cancel (GTC)", IsRequired = true)]
		public char TIF { get; set; }


		[ApiMember(Description = "Used to specify that this order replaces another")]
		public long CancelReplaceSignalId { get; set; }


		[ApiMember(Description = "Used to specify that this order is conditional (a child) on another")]
		public long ParentSignalId { get; set; }


		[ApiMember(Description = "The C2 symbol group")]
		public C2symbol C2Symbol { get; set; }


		[ApiMember(Description = "The exchange symbol group")]
		public Exchangesymbol ExchangeSymbol { get; set; }
    }

}


namespace TDLib
{
    public partial class TDConnection
    {
        public GetStrategyActiveOrdersResponse GetStrategyActiveOrders(long StrategyID)
        {
            //string Url = $"https://api4.collective2.com:443/Strategies/GetStrategyActiveOrders?strategyId={StrategyID}";

            try
            {
                var client = ServiceStackJsonClient.CreateClient(AppKeys.Collective2APIKey);
                var request = new GetStrategyActiveOrders();
                request.StrategyId = StrategyID;
                return client.Get(request);

                //using (HttpClient httpClient = new HttpClient())
                //{
                //    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //    var postRequest = new HttpRequestMessage(HttpMethod.Get, Url);

                //    postRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", AppKeys.Collective2APIKey);

                //    var postResponse = await httpClient.SendAsync(postRequest);

                //    postResponse.EnsureSuccessStatusCode();

                //    string json = await postResponse.Content.ReadAsStringAsync();

                //    GetStrategyActiveOrdersModel oModel = JsonSerializer.Deserialize<GetStrategyActiveOrdersModel>(json);

                //    return oModel;

                //}
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return null;
        }
    }
}