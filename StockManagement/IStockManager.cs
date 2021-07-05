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
    }
}
