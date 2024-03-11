using StockManager.Client.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Portfolio
    {
        public decimal AvailableFunds { get; set; }
        public List<Stock> Stocks { get; set; }
        
        public decimal PortfolioValue
        {
            get
            {
                decimal value = 0;
                foreach (Stock stock in Stocks)
                {
                    value += stock.price;
                }
                return value;
            }
        }
        

        public Portfolio()
        {
            Stocks = new List<Stock>();
            AvailableFunds = 100000;
        }

        public void BuyStock(Stock stock, int quantity)
        {
            decimal totalPrice = stock.price * quantity;

            if (AvailableFunds >= totalPrice)
            {
                AvailableFunds -= totalPrice;

                Stock existingStock = Stocks.FirstOrDefault(s => s.ticker == stock.ticker);
                if (existingStock != null)
                {
                    existingStock.Quantity += quantity;
                }
                else
                {
                    stock.Quantity = quantity;
                    Stocks.Add(stock);
                }
            }
        }





        public void SellStock(Stock stock)
        {

            if(Stocks.Count > 0)
            {
                AvailableFunds += stock.price;
                Stocks.Remove(stock);
            }
            
        }

        public int GetAmountOfStock(Stock stock)
        {
            return stock.Quantity;
        }



    }

}
