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
        public AppKeysModel AppKeys { get; set; }

        public TDConnection()
        {
            using (Stream s = Assembly.GetExecutingAssembly().GetManifestResourceStream("TDLib.appkeys.json"))
            {
                if (s == null) throw new Exception("Unable to find key file TDLib.appkeys.json");
                using (StreamReader sr = new StreamReader(s))
                {
                    string keys = sr.ReadToEnd();
                    if (String.IsNullOrEmpty(keys))
                    {
                        throw new Exception("appkeys.json file is blank or null");
                    }
                    /*
                     * Read the key file and pull out the account values we need
                     */
                    AppKeys = JsonSerializer.Deserialize<AppKeysModel>(keys);   
                }
            }
        }
    }
}
