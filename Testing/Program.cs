using DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using BusinessLayer;

namespace Testing;

class Program
{
    static void Main(string[] args)
    {
        YahooAPI yahooAPI = new YahooAPI();

        string closePrice = yahooAPI.StockPricePreviousClose("AAPL").Result;

        Console.WriteLine($"The previous close price for AAPL is {closePrice}");


    }
}
