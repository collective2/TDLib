using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDLib.ExecutionModel
{

    public class Rootobject
    {
        public enum eActivityType
        {
             EXECUTION,ORDER_ACTION
        }

        public enum eExecutionType
        {
            FILL
        }
        public string activityType { get; set; }
        
        // only one value for execution type
        public string executionType { get; set; } 
        public double quantity { get; set; }
        public double orderRemainingQuantity { get; set; }
        public Executionlegs[] executionLegs { get; set; }
    }
  
     public class Executionlegs
    {
        public int legId { get; set; }
        public double quantity { get; set; }
        public double mismarkedQuantity { get; set; }
        public double price { get; set; }
        public DateTime time { get; set; }
    }


 
}
