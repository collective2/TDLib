using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDLib.Collective2
{
    public class CursorPaginatedRequestBase
    {
        private static int MaxTake = 100;
        private int sLimit = MaxTake;


        public string Cursor { get; set; }


        /// <summary>
        /// C2 will enforce a size limit for all endpoints. Default is 100
        /// </summary>
        public int Limit 
        {
            get
            {
                return sLimit;
            }
            set 
            {
                 sLimit = Math.Min(value, MaxTake);
            } 
        }
    }
}
