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
    public class PendingOrderModel
    {
        public string session { get; set; }
        public string duration { get; set; }
        public string orderType { get; set; }
        public string complexOrderStrategyType { get; set; }
        public decimal quantity { get; set; }
        public decimal filledQuantity { get; set; }
        public decimal remainingQuantity { get; set; }
        public string requestedDestination { get; set; }
        public string desinationLinkName { get; set; }
        public decimal price { get; set; }
        public PendingOrderLeg[] orderLegCollection { get; set; }
        public string orderStrategyType { get; set; }
        public long orderId { get; set; }
        public bool cancelable { get; set; }
        public bool editable { get; set; }
        public string status { get; set; }
        public string enteredTime { get; set; }
        public int accountId { get; set; }
        public PendingOrderModel[] childOrderStrategies { get; set; }

    }
}
