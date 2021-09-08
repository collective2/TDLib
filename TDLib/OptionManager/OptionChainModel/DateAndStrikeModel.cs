using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace TDLib
{
    public class DateAndStrikeModel
    {
        public string expdate { get; set; }
        public StrikeAndOptions strike { get; set; } = new StrikeAndOptions();
    }
}
