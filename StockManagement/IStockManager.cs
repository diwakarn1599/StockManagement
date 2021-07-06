using System;
using System.Collections.Generic;
using System.Text;

namespace StockManagement
{
    interface IStockManager
    {
        /// <summary>
        /// Interface for Stock Manager
        /// </summary>
        /// <param name="stockList"></param>
        public void DisplayStocks(List<StocksUtility.Stocks> stockList);
        public void CalculateValueOfEachStock(List<StocksUtility.Stocks> stockList);
        public void CalculateValueOfAllStocks(List<StocksUtility.Stocks> stockList);
        public void BuyStocks(string jsonFilePathOfStocks);
        public void SellStocks(string jsonFilePathOfStocks);
        public bool CheckAvailablity(string nameOfStock, int volumeOfStock, List<StocksUtility.Stocks> stockList);
        public bool CheckAvailablity(string nameOfStock, int volumeOfStock, LinkedList<StocksUtility.UserStocks> stockList, string nameOfPerson);
        public bool CheckExists(LinkedList<StocksUtility.UserStocks> stockList, string name,string nameOfPerson);
        public bool CheckExists(List<StocksUtility.Stocks> stockList, string name);
        public void CalculateValueOfAllStocks(List<StocksUtility.UserStocks> stockList);
        public void CalculateValueOfEachStock(List<StocksUtility.UserStocks> stockList);
        public void PrintReport();
    }
}
