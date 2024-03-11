﻿namespace StockManager.Client.Models
{
    public class User
    {
        public int userId { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public List<Stock> stocks { get; set; }

        public User(string username, string password)
        {
            this.username = username;
            this.password = password;
            stocks = new List<Stock>();
        }
    }
}