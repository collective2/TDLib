using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace TDLib
{

    public partial class ExpirationDateMap : JsonObjectBuilder
    {
        public List<DateAndStrikeModel> DateAndStrikeList { get; set; } = new List<DateAndStrikeModel>();

        public override void LoadObject(string Name, JsonElement oEle)
        {
            if (Name != "")
            {
                /*
                 * This is a list, not an array. add to the list
                 */
                DateAndStrikeModel o = new DateAndStrikeModel();
                DateAndStrikeList.Add(o);

                o.expdate = Name;
                o.strike.LoadObject("", oEle);
            }
            else
            {
                base.LoadObject(Name, oEle);
            }
        }
        public override void LoadArray(string Name, JsonElement oEle)
        {
            base.LoadArray(Name, oEle);
        }
        public override void LoadVariable(string Name, JsonElement Value)
        {
            Console.WriteLine($"load variable {Name}");
        }
    }
}
