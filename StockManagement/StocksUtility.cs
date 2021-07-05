﻿using System;
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
        public class Stocks
        {
            public string name { get; set; }
            public int volume { get; set; }
            public int price { get; set; }
        }
    }
}
