using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack;

namespace TDLib.Collective2
{

    public class GetStrategyOpenPositions: ResponseBase<GetStrategyOpenPositionsResponse>
    {
		[ApiMember(Description = @"The Strategy ID", IsRequired = true)]
        public long? StrategyId { get; set; }


        [ApiMember(Description = "(Optional) AssetClass filter. e.g. 'stock', 'option', 'future', 'forex', 'crypto'")]
        public string AssetClass { get; set; }
    }

	[ApiResponse(Description = "The list of open positions for the strategy")]
    public class GetStrategyOpenPositionsResponse : ResponseBase<PositionDTO>
    {
    }

    public class PositionDTO
    {
        [ApiMember(Description = "The C2 StrategyId")]
        public long StrategyId { get; set; }


		[ApiMember(Description = "The 3-character ISO instrument currency. E.g. 'USD'")]
		public string Currency { get; set; }


		[ApiMember(Description = "The net position quantity. Short positions will be negative.")]
		public decimal Quantity { get; set; }


		[ApiMember(Description = "UTC DateTime when the position was opened")]
		public DateTime OpenedDate { get; set; }

		
		[ApiMember(Description = "The position average price")]
		public decimal AvgPx { get; set; }


		[ApiMember(Description = "The C2 symbol group")]
		public C2symbol C2Symbol { get; set; } = new C2symbol();


		[ApiMember(Description = "The exchange symbol group")]
		public Exchangesymbol ExchangeSymbol { get; set; } = new Exchangesymbol();
    }



}
