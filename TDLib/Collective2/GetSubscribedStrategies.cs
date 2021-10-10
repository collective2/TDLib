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
using ServiceStack;

namespace TDLib
{
    public partial class TDConnection
    {
        public GetSubscribedStrategiesResponse GetSubscribedStrategies(long personId)
        {
            //string Url = $"https://api4.collective2.com:443/General/GetSubscribedStrategies?personId={AppKeys.Collective2PersonID}";

            try
            {
                var client = ServiceStackJsonClient.CreateClient(AppKeys.Collective2APIKey);
                var request = new GetSubscribedStrategies();
                request.PersonId = personId;
                return client.Get(request);


                //using (HttpClient httpClient = new HttpClient())
                //{
                //    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //    var postRequest = new HttpRequestMessage(HttpMethod.Get, Url);
 
                //    postRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", AppKeys.Collective2APIKey);

                //    var postResponse = await httpClient.SendAsync(postRequest);

                //    postResponse.EnsureSuccessStatusCode();

                //    string json = await postResponse.Content.ReadAsStringAsync();

                //    GetSubscribedStrategiesModel oModel = JsonSerializer.Deserialize<GetSubscribedStrategiesModel>(json);

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


namespace TDLib.Collective2
{
    [Api]
    [Route("/General/GetSubscribedStrategies", "GET", Summary = "Request the subscribed strategies of the person", Notes = "Paginated endpoint")]
    public class GetSubscribedStrategies : CursorPaginatedRequestBase, IGet, IReturn<GetSubscribedStrategiesResponse>
    {
        [ApiMember(Description = "PersonId", IsRequired = true)]
        public long PersonId { get; set; }
    }

    [ApiResponse(Description = "List of currently subscribed strategies")]
    public class GetSubscribedStrategiesResponse : ResponseBase<SubcribedStrategyDTO>
    {
    }
 
    public class SubcribedStrategyDTO
    {
        [ApiMember(Description = @"The Subscription ID")]
        public long Id { get; set; }


        [ApiMember(Description = @"The C2 PersonId")]
        public long PersonId { get; set; }


        [ApiMember(Description = @"The C2 SystemID")]
        public long StrategyId { get; set; }


        [ApiMember(Description = @"The Strategy Name")]
        public string StrategyName { get; set; }


        [ApiMember(Description = @"TRUE if the person is Autotrading as a simulation")]
        public bool IsSimulation { get; set; }


        [ApiMember(Description = @"TRUE if the person is Autotrading in a PaperTrade account")]
        public bool IsPaperTrade { get; set; }       


        [ApiMember(Description = @"UTC Date when the person subscribed to the Strategy")]
        public DateTime SubscriptionDate { get; set; }
    }


   
}
