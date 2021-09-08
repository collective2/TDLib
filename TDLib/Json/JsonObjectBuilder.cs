using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


namespace TDLib
{
    public partial class JsonObjectBuilder
    {

        /// <summary>
        /// At the top level JSON is either an object { .. } or an array of objects [{ .. },{.. }]
        /// </summary>
        /// <param name="json"></param>
        public void Load(string json)
        {
            JsonDocument oDoc = JsonDocument.Parse(json);

            JsonElement oEle = oDoc.RootElement;

            switch (oEle.ValueKind)
            {
                case JsonValueKind.Object:
                    LoadObject("",oEle);
                    break;
                case JsonValueKind.Array:
                    LoadArray("",oEle);
                    break;
            }

        }

        /// <summary>
        /// Load the object 
        /// </summary>
        /// <param name="oTokenizer"></param>
        public virtual void LoadObject(string Name,JsonElement oEle)
        {
            foreach (var v in oEle.EnumerateObject())
            {
                switch (v.Value.ValueKind)
                {
                    case JsonValueKind.Object:
                        LoadObject(v.Name,v.Value);
                        break;
                    case JsonValueKind.Array:
                        LoadArray(v.Name,v.Value);
                        break;
                    case JsonValueKind.String:
                    case JsonValueKind.Number:
                    case JsonValueKind.Null:
                    case JsonValueKind.False:
                    case JsonValueKind.True:
                        LoadVariable(v.Name,v.Value);
                        break;
 
                    default:
                        throw new Exception($"expected object element, found token type {v.Value.ValueKind}");
                }
            }
        }

        /// <summary>
        /// Load an array value
        /// </summary>
        /// <param name="oTokenizer"></param>
        public virtual void LoadArray(string Name,JsonElement oEle)
        {
            foreach (var v in oEle.EnumerateArray())
            {
                switch (v.ValueKind)
                {
                    case JsonValueKind.Object:
                        LoadObject("",v);
                        break;
                    case JsonValueKind.Array:
                        LoadArray("",v);
                        break;
                    default:
                        throw new Exception($"expected object element, found token type {v.ValueKind}");
                }
            }

        }

        /// <summary>
        /// variable can be a simple value, array or an object
        /// </summary>
        /// <param name="oTokenizer"></param>
        public virtual void LoadVariable(string Name,JsonElement Value)
        {
            Console.WriteLine($"Variable with name {Name} = {Value.ToString()}");


        }

  
    }
}
