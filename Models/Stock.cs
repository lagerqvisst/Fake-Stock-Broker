namespace StockManager.Client.Models
{
    public class Stock
    {
        public string name { get; set; }
        public string ticker { get; set; }
        public decimal price { get; set; }
        public int Quantity { get; set; } // Antal aktier



        public Stock(string name)
        {
            this.name = name;
            Quantity = 0;




        }   


    }
}
