using System.Text.Json;
using Microsoft.EntityFrameworkCore.Metadata;
using Models;
using StockManager.Client.Models;

namespace BusinessLayer
{
    public class YahooAPI
    {
        public string APIKEY = "v3QUu6bQ1Bhxj79xec10yX3KVith16fz";

        public async Task<List<Stock>> GetStocks(string search)
        {
            List<Stock> stocks = new List<Stock>();

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string url = $"https://api.polygon.io/v3/reference/tickers?search={search}&active=true&apiKey={APIKEY}";

                    HttpResponseMessage response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResponse = await response.Content.ReadAsStringAsync();
                        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                        var data = JsonSerializer.Deserialize<TickerResponse>(jsonResponse, options);

                        foreach (var result in data.Results)
                        {
                            Stock stock = new Stock(result.Name);
                            stock.ticker = result.Ticker;
                            stocks.Add(stock);
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Error: {response.StatusCode}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }

            return stocks;
        }


        public async Task<string> StockPricePreviousClose(string ticker)
        {
            string previousClose = string.Empty;

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string url = $"https://api.polygon.io/v2/aggs/ticker/{ticker}/prev?adjusted=true&apiKey={APIKEY}";

                    HttpResponseMessage response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResponse = await response.Content.ReadAsStringAsync();
                        Console.WriteLine($"JSON Response: {jsonResponse}");

                        // Skapa en JsonDocument från JSON-strängen
                        using (JsonDocument document = JsonDocument.Parse(jsonResponse))
                        {
                            // Navigera till det första objektet i results-arrayen och hämta värdet för C
                            JsonElement root = document.RootElement;
                            JsonElement results = root.GetProperty("results");
                            JsonElement firstResult = results[0];
                            JsonElement cValue = firstResult.GetProperty("c");

                            // Konvertera C-värdet till en sträng och sätt det som previousClose
                            previousClose = cValue.GetDecimal().ToString();
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Error: {response.StatusCode}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }

            return previousClose;
        }





    }



    public class TickerResponse
    {
        public List<TickerResult> Results { get; set; }
    }

    public class TickerResult
    {
        public string Name { get; set; }
        public string Ticker { get; set; }


    }
}
