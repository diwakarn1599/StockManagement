using System;
using System.Collections.Generic;
using System.Text;

namespace StockManagement
{
    class StockManager:IStockManager
    {
        /// <summary>
        /// Display stocks in json list
        /// </summary>
        /// <param name="stockList"></param>
        public void DisplayStocks(List<StocksUtility.Stocks> stockList)
        {
           // StocksUtility.Stocks su = new StocksUtility.Stocks();
            foreach(StocksUtility.Stocks i in stockList)
            {
                Console.WriteLine($"Name ={i.name}\nVolume={i.volume}\nPrice={i.price}\n***********");
            }
        }
        /// <summary>
        /// Calculate value of each stock
        /// </summary>
        /// <param name="stockList"></param>
        public void CalculateValueOfEachStock(List<StocksUtility.Stocks> stockList)
        {
            // StocksUtility.Stocks su = new StocksUtility.Stocks();
            foreach (StocksUtility.Stocks i in stockList)
            {
                Console.WriteLine($"Name ={i.name}\nVolume={i.volume}\nPrice={i.price}\n**********");
                Console.WriteLine($"Total value of {i.name} share is {i.volume*i.price}\n");

            }
        }
        /// <summary>
        /// Calculate values for all stocks
        /// </summary>
        /// <param name="stockList"></param>
        public void CalculateValueOfAllStocks(List<StocksUtility.Stocks> stockList)
        {
            int totalShareOfCompanies = 0;
            int valueOfEachCompany;
            // StocksUtility.Stocks su = new StocksUtility.Stocks();
            foreach (StocksUtility.Stocks i in stockList)
            {
                Console.WriteLine($"Name ={i.name}\nVolume={i.volume}\nPrice={i.price}\n***********");
                valueOfEachCompany = i.volume * i.price;
                Console.WriteLine($"Total value of {i.name} share is {valueOfEachCompany}");
                totalShareOfCompanies += valueOfEachCompany;

            }
            Console.WriteLine("***********Total Values Of all Shares***********");
            Console.WriteLine($"Total Value of all shares is {totalShareOfCompanies}"); 
        }
    }
}
