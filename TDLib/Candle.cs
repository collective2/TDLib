using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDLib
{
    public class Candle
    {
        public decimal Open { get; set; }
        public decimal High { get; set; }
        public decimal Low { get; set; }

        public decimal Close { get; set; }

        public long Volume { get; set; }
        public long MillisecondsSinceJan_1_1970 { get; set; }

        // Adjust the date/time for the time zone. may have to watch for daylight time
        public DateTime DtTimeZoneAdjusted
        {
            get
            {
                return dt.AddHours(-5);
            }
        }
        public DateTime dt
        {
            get
            {
                return new DateTime(1970, 1, 1).AddMilliseconds(MillisecondsSinceJan_1_1970);
            }
        }
    }
}
