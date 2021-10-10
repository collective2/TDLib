using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ServiceStack;
using ServiceStack.Host;

namespace TDLib.Collective2
{
    /// <summary>
    /// https://docs.servicestack.net/error-handling
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ResponseBase<T> : IHasResponseStatus
    {
        [ApiMember(Description = "Result array")]
        public virtual List<T> Results { get; set; }


        [ApiMember(Description = "Pagination data, if any")]
        public virtual Dictionary<string, string> Pagination { get; set; }


        [ApiMember(Description = "The ResponseStatus. The Statuscode will be the same as in the HTTP header")]
        public virtual ResponseStatus ResponseStatus { get; set; } = new ResponseStatus("200");
    }

    public class C2symbol
    {
		[ApiMember(Description = "The full native C2 symbol e.g. BSRR2121Q22.5", IsRequired = true)]
		public string FullSymbol { get; set; }

		/// <summary>
		/// See AssetClass.cs
		/// </summary>
		[ApiMember(Description = "The type of instrument. e.g. 'stock', 'option', 'future', 'forex', 'crypto'", IsRequired = true)]
		public string SymbolType { get; set; }

		[ApiMember(Description = "Option Underlying symbol")]
		public string Underlying { get; set; }

		[ApiMember(Description = "Option expiry. Format is 'May21'")]
		public string Expiry { get; set; }

		[ApiMember(Description = "Option 'put' or 'call'")]
		public string PutOrCall { get; set; }

		[ApiMember(Description = "Option strike price")]
		public decimal StrikePrice { get; set; }
    }
    public class Exchangesymbol
    {
        [ApiMember(Description = "The exchange symbol e.g. AAPL", IsRequired = true)]
        public string Symbol { get; set; }


        [ApiMember(Description = "The 3-character ISO instrument currency. E.g. 'USD'", IsRequired = true)]
		public string Currency { get; set; }


        [ApiMember(Description = @"The ISO Exchange code e.g. DEFAULT (for stocks & options), XCME, XEUR, etc. See http://www.iso15022.org/MIC/homepageMIC.htm", IsRequired = true)]
        public string SecurityExchange { get; set; } = "DEFAULT";


        [ApiMember(Description = "The SecurityType e.g. 'CS', 'FUT', 'OPT', 'FOR'", IsRequired = true)]
        public string SecurityType { get; set; }


        [ApiMember(Description = "The MaturityMonthYear e.g. '202103' (March 2021), or if teh contract requires a day: '20210521' (May 21, 2021)")]
        public string MaturityMonthYear { get; set; }

        //[ApiMember(Description = "The ISO Underlying MaturityMonthYear e.g. '202103' (March 2021). Not currently in use.")]
        //public string UnderlyingMaturityMonthYear { get; set; }

        [ApiMember(Description = "The Option PutOrCall e.g. 0 = Put, 1 = Call")]
        public int PutOrCall { get; set; }


        [ApiMember(Description = "The ISO Option Strike Price. Zero means none")]
        public decimal StrikePrice { get; set; }


        [ApiMember(Description = "The multiplier to apply to the Exchange price to get the C2-formatted price. Default is 1")]
        public decimal PriceMultiplier { get; set; } = 1;
    }
}
