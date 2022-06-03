using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack;

namespace TDLib.Collective2
{
    public class ServiceStackJsonClient
    {
        public static IServiceClient CreateClient(string collective2APIKey)
        {
            IServiceClient client = new JsonServiceClient(@"https://api4-general.collective2.com").WithCache();
            client.AddHeader("Accept", "application/json");
            client.AddHeader("Authorization", $"Bearer {collective2APIKey}");
            return client;
        }
    }
}
