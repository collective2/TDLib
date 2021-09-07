using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Text.Json;
using System.Configuration;
using System.Reflection;
using System.IO;

namespace TDLib
{
    /// <summary>
    /// Read the doc 'GettingTheKeys.pdf' for a discussion of the API values you will need
    /// We only need to store 3 values in the appkeys.json
    /// </summary>
    public partial class TDConnection
    {
        public string ConsumerKey = "";     // this is a 30 character or so Alphanumberic string, e.g. S29KFH7093WERTMNCC555
      
        public string refresh_token = "";   // This is 900+ long character string

        public string AccountNumber = "";   // this is the 9 digit value from tdameritrade.com

        public TDConnection()
        {
            string keys = "";
            using (Stream s = Assembly.GetExecutingAssembly().GetManifestResourceStream("TDLib.appkeys.json"))
            {
                if (s == null) throw new Exception("Unable to find key file TDLib.appkeys.json");
                using (StreamReader sr = new StreamReader(s))
                {
                    keys = sr.ReadToEnd();
                    if (String.IsNullOrEmpty(keys))
                    {
                        throw new Exception("appkeys.json file is blank or null");
                    }
                    /*
                     * Read the key file and pull out the account values we need
                     */
                    AppKeysModel oModel = JsonSerializer.Deserialize<AppKeysModel>(keys);

                    AccountNumber = oModel.AccountNumber;
                    ConsumerKey = oModel.ConsumerKey;
                    refresh_token = oModel.refresh_token;
                }
            }

        }

        /*
         * Work class used to deserialize data from the appkeys.json
         */
        class AppKeysModel
        {
            public string ConsumerKey { get; set; } 
            public string AccountNumber { get; set; }
            public string refresh_token { get; set; }

        }
    }
}
