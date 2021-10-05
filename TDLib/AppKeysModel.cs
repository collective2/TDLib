using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDLib
{
    /*
     * Work class used to deserialize data from the appkeys.json
     */
    public class AppKeysModel
    {
        public string ConsumerKey { get; set; }
        public string AccountNumber { get; set; }
        public string refresh_token { get; set; }
        public string Collective2APIKey { get; set; }
        public string Collective2PersonID { get; set; }

    }
}
