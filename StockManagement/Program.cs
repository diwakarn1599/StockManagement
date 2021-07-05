﻿using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace StockManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            StockManager sm = new StockManager();
            Console.WriteLine("****************Welcome to Stock Management Program!!!****************");
            string jsonFilePath = @"C:\Users\NARD'S IDEAPAD\source\repos\StockManagement\StockManagement\Stocks.json";
            StocksUtility utility = JsonConvert.DeserializeObject<StocksUtility>(File.ReadAllText(jsonFilePath));
            Console.WriteLine("******MENU*******");
            Console.WriteLine("1.Display Stocks \n2.Calculate value of each stock \n3.Calculate Total value of stocks\n4.Exit\nEnter an Option");
            switch (Convert.ToInt32(Console.ReadLine()))
            {
                case 1:
                    sm.DisplayStocks(utility.stockList);
                    break;
                case 2:
                    sm.CalculateValueOfEachStock(utility.stockList);
                    break;
                case 3:
                    sm.CalculateValueOfAllStocks(utility.stockList);
                    break;
                case 4:
                    Console.WriteLine("Exited");
                    break;
            }
        }
    }
}
