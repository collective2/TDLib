using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDLib;

namespace HelloWorld
{
    /// <summary>
    /// Basic Hello World program. If this runs and pulls the latest quote for the spy then you will have set up your keys successfully
    /// in appkeys.json
    /// Read the file GettingTheKeys.pdf to learn how to retrieve the various values you will need.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            TDConnection oTDA = new TDConnection();

            string accesstoken = oTDA.GetAccessToken();

            List<QuoteData> quoteList = oTDA.GetLatestQuotes("SPY", accesstoken);

            Console.WriteLine($"Latest spy quote is {quoteList[0].lastPrice}");
        }
    }
}
