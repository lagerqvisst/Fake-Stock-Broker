using Models;

namespace StockManager.Client.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public List<Stock> stocks { get; set; }

        public Portfolio portfolio { get; set; }

        public User(string username, string password)
        {
            this.username = username;
            this.password = password;
            stocks = new List<Stock>();
            portfolio = new Portfolio();
        }
    }
}
