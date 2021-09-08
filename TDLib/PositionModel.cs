using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TDLib
{
    /// <summary>
    /// This is a class just used to do trades for a stock. It only generates the JSON needed
    /// without includings other fields or nulls
    /// </summary>
    /// 

    public class SecuritiesAccountModel
    {
        public SecuritiesAccountDetailsModel securitiesAccount { get; set; }

    }
    public class SecuritiesAccountDetailsModel
    {
        public string type { get; set; }
        public string accountId { get; set; }

        public int roundTrips { get; set; }

        public bool isDayTrader { get; set; }
        
        public bool isClosingOnlyRestricted { get; set; }

        public PositionModel[] positions { get; set; }

    }
    public class PositionModel
    {
        public OptionTickerDetails optionDetails { get; set; }
        public decimal shortQuantity { get; set; }
        public decimal averagePrice { get; set; }
        public decimal currentDayProfitLoss { get; set; }
        public decimal currentDayProfitLossPercentage { get; set; }
        public decimal longQuantity { get; set; }
        public decimal settledLongQuantity { get; set; }
        public decimal settledShortQuantity { get; set; }

        public Instrument instrument { get; set; }
        public decimal marketValue { get; set; }
        public decimal maintenanceRequirement { get; set; }
        public decimal currentDayCost { get; set; }
        public decimal previousSessionLongQuantity { get; set; }

    }
}
