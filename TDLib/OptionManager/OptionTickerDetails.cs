using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;

namespace TDLib
{

    public class OptionTickerDetails
    {
        public bool IsOption { get; set; } = false;
        /*
         * Properties
         */
        public DateTime ExpirationDate { get; set; }
      
        public string Ticker { get; set; }
        public string OptionType { get; set; }

        public bool IsCallOption()
        {
            if (OptionType == "C") return true;
            else return false;
        }
        public bool IsPutOption()
        {
            if (OptionType == "P") return true;
            else return false;
        }

        public decimal StrikePrice { get; set; }

        public int DaysToExpiration
        {
            get
            {
                TimeSpan ts = (ExpirationDate - System.DateTime.Today);

                return (int) ts.TotalDays;
            }
        }

        /*
         * 
         */
        public OptionTickerDetails(string s)
        {
            // format of ticker must be validated

            IsOption = false;
            // formqt is ticker_mmmmyyCStrike

            string[] components = s.Split("_".ToCharArray());
            if (components.Length != 2) return;

            // set ticker name
            Ticker = components[0];
            string dt = components[1];

            int mm = Convert.ToInt32(dt.Substring(0, 2));
            int dd = Convert.ToInt32(dt.Substring(2, 2));
            int yy = 2000 + Convert.ToInt32(dt.Substring(4, 2));

            ExpirationDate = new DateTime(yy, mm, dd);

            OptionType = dt.Substring(6,1);

            StrikePrice = Convert.ToDecimal(dt.Substring(7));

            IsOption = true;


        }

    }
}
