namespace StockManager.Client.Models
{
    public class Stock
    {
        public int StockId { get; set; }
        public string Name { get; set; }
        public string Ticker { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; } // Antal aktier

        public decimal totalValue
        {
            get
            {
                return Price * Quantity;
            }
        }


        public Stock(string name)
        {
            Name = name;

        }


    }

}
