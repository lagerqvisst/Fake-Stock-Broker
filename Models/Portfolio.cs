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
        public int PortfolioId { get; set; } //PL
        public int UserId { get; set; } //FK
        public decimal AvailableFunds { get; set; }
        public List<Stock> Stocks { get; set; }
        
        public decimal PortfolioValue
        {
            get
            {
                decimal value = 0;
                foreach (Stock stock in Stocks)
                {
                    value += stock.totalValue;
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
            decimal totalPrice = stock.Price * quantity;

            if (AvailableFunds >= totalPrice)
            {
                AvailableFunds -= totalPrice;

                Stock existingStock = Stocks.FirstOrDefault(s => s.Ticker == stock.Ticker);
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

        public void SellStock(Stock stock, int quantity)
        {
            Stock existingStock = Stocks.FirstOrDefault(s => s.Ticker == stock.Ticker);
            if (existingStock != null)
            {
                if (existingStock.Quantity >= quantity)
                {
                    existingStock.Quantity -= quantity;
                    AvailableFunds += stock.Price * quantity;

                    // Om hela innehavet har sålts, ta bort aktien från portföljen
                    if (existingStock.Quantity == 0)
                    {
                        Stocks.Remove(existingStock);
                    }
                }
            }
        }






        public int GetAmountOfStock(Stock stock)
        {
            return stock.Quantity;
        }



    }

}
