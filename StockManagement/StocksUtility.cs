using System;
using System.Collections.Generic;
using System.Text;

namespace StockManagement
{
    class StocksUtility
    {
        /// <summary>
        /// list for stocks
        /// </summary>
        public List<Stocks> stockList { get; set; }
        /// <summary>
        /// Linked List for storing user stocks
        /// </summary>
        public LinkedList<UserStocks> userStockList { get; set;}
        public class Stocks
        {
            public string name { get; set; }
            public int volume { get; set; }
            public int price { get; set; }
        }

        public class UserStocks
        {
            public string name { get; set; }
            public int volume { get; set; }
            public int price { get; set; }
        }
    }
}
