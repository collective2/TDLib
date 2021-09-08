using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TDLib
{
    public partial class TDConnection
    {
        /// <summary>
        /// Parse the JSON result to pull list of candle values from routines that return candles
        /// </summary>
        /// <param name="Result"></param>
        /// <returns></returns>
        protected List<Candle> GetCandleList(string Result)
        {
            List<Candle> CandleList = new List<Candle>();

            using (JsonDocument document = JsonDocument.Parse(Result))
            {
                JsonElement root = document.RootElement;
                JsonElement candleArray = root.GetProperty("candles");

                foreach (JsonElement candle in candleArray.EnumerateArray())
                {
                    Candle c = new Candle();
                    CandleList.Add(c);

                    if (candle.TryGetProperty("open", out JsonElement openProperty))
                    {
                        c.Open = openProperty.GetDecimal();
                    }

                    if (candle.TryGetProperty("high", out JsonElement highProperty))
                    {
                        c.High = highProperty.GetDecimal();
                    }

                    if (candle.TryGetProperty("low", out JsonElement lowProperty))
                    {
                        c.Low = lowProperty.GetDecimal();
                    }

                    if (candle.TryGetProperty("close", out JsonElement closeProperty))
                    {
                        c.Close = closeProperty.GetDecimal();
                    }

                    if (candle.TryGetProperty("volume", out JsonElement volumeProperty))
                    {
                        c.Volume = volumeProperty.GetInt64();
                    }

                    if (candle.TryGetProperty("datetime", out JsonElement datetimeProperty))
                    {
                        c.MillisecondsSinceJan_1_1970 = datetimeProperty.GetInt64();
                    }
                }
            }

            return CandleList;
        }
    }
}
