namespace StockManager.Client.Models
{
    public class Stock
    {
        public int stockId { get; set; }
        public string name { get; set; }
        public string ticker { get; set; }

        public string previousClose { get; set; }


        public Stock(string name)
        {
            this.name = name;

        }
    }
}
