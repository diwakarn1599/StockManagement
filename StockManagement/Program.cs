using System;
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

            string jsonFilePathOfStocks = @"C:\Users\NARD'S IDEAPAD\source\repos\StockManagement\StockManagement\Stocks.json";
            

            //*************************************************************************************************************************
            while (true)
            {
                StocksUtility utilityOfStockList = JsonConvert.DeserializeObject<StocksUtility>(File.ReadAllText(jsonFilePathOfStocks));
                Console.WriteLine("**********************************************************************");
                Console.WriteLine("******MENU*******");

                Console.WriteLine("1.Display Stocks \n2.Calculate value of each stock \n3.Calculate Total value of stocks\n4.Buy Stocks\n5.Sell Stocks\n6.Print Report\n7.Exit\nEnter an Option");
                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:
                        sm.DisplayStocks(utilityOfStockList.stockList);
                        sm.DisplayStocks(utilityOfStockList.userStockList);
                        break;
                    case 2:
                        sm.CalculateValueOfEachStock(utilityOfStockList.stockList);
                        break;
                    case 3:
                        sm.CalculateValueOfAllStocks(utilityOfStockList.stockList);
                        break;
                    case 4:
                        Console.WriteLine("***********Buy Stocks*************");
                        sm.BuyStocks(jsonFilePathOfStocks);
                        break;
                    case 5:
                        Console.WriteLine("**********Sell Stocks************");
                        sm.SellStocks(jsonFilePathOfStocks);
                        break;
                    case 6:
                        Console.WriteLine("********Print Report*************");
                        sm.PrintReport();
                        break;
                    case 7:
                        Console.WriteLine("Exited");
                        return;
                        
                }
            }
        }
    }
}
