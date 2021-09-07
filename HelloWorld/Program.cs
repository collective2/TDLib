using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDLib;

namespace HelloWorld
{
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
