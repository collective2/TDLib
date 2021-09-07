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
        /// Parse the JSON result to pull list of quote values the gets quote data for multiple tickers
        /// </summary>
        /// <param name="Result"></param>
        /// <returns></returns>
        protected List<QuoteData> GetQuoteDataList(string Result)
        {
            List<QuoteData> QuoteDataList = new List<QuoteData>();

            using (JsonDocument document = JsonDocument.Parse(Result))
            {
                JsonElement root = document.RootElement;
                /*
                 * The result list is an object with a set of fields, each of which is an object.
                 * "IBM": {data},
                 * "TSLA": {data},
                 * "AAPL": {data}
                 * 
                 * This means we enumerate the properties of the object, which are the tickers.
                 * We pull the ticker from the data so we don't need it as the name
                 * Shoulda been an array, but no one asked me...
                 */

                foreach (JsonProperty quote in root.EnumerateObject())
                {
                    QuoteData q = new QuoteData();
                    QuoteDataList.Add(q);

                    JsonElement qValue = quote.Value;

                    if (qValue.TryGetProperty("assetType", out JsonElement assetTypeProperty))
                    {
                        q.assetType = assetTypeProperty.GetString();
                    }

                    if (qValue.TryGetProperty("symbol", out JsonElement symbolProperty))
                    {
                        q.symbol = symbolProperty.GetString();
                    }

                    if (qValue.TryGetProperty("lastPrice", out JsonElement lastPriceProperty))
                    {
                        q.lastPrice = lastPriceProperty.GetDecimal();
                    }

                    if (qValue.TryGetProperty("openPrice", out JsonElement openPriceProperty))
                    {
                        q.openPrice = openPriceProperty.GetDecimal();
                    }

                    if (qValue.TryGetProperty("lowPrice", out JsonElement lowPriceProperty))
                    {
                        q.lowPrice = lowPriceProperty.GetDecimal();
                    }

                    if (qValue.TryGetProperty("highPrice", out JsonElement highPriceProperty))
                    {
                        q.highPrice = highPriceProperty.GetDecimal();
                    }

                    if (qValue.TryGetProperty("closePrice", out JsonElement closePriceProperty))
                    {
                        q.closePrice = closePriceProperty.GetDecimal();
                    }

                    if (qValue.TryGetProperty("totalVolume", out JsonElement totalVolumeProperty))
                    {
                        q.totalVolume = totalVolumeProperty.GetInt32();
                    }
                }
            }

            return QuoteDataList;
        }
    }
}
