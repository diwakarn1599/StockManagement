using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

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
            
            Console.WriteLine("*********STOCKS AVAILABLE***************");
            foreach (StocksUtility.Stocks i in stockList)
            {
                Console.WriteLine($"Name ={i.name}\nVolume={i.volume}\nPrice={i.price}\n***********");
            }
        }
        public void DisplayStocks(LinkedList<StocksUtility.UserStocks> stockList)
        {
            // StocksUtility.Stocks su = new StocksUtility.Stocks();
            Console.WriteLine("*********YOUR STOCKS***************");
            foreach (StocksUtility.UserStocks i in stockList)
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
        /// <summary>
        /// Calculate value of each user stock
        /// </summary>
        /// <param name="stockList"></param>
        public void CalculateValueOfEachStock(List<StocksUtility.UserStocks> stockList)
        {
            // StocksUtility.Stocks su = new StocksUtility.Stocks();
            Console.WriteLine("***********TOTAL VALUE OF EACH USER STOCK***********");
            foreach (StocksUtility.UserStocks i in stockList)
            {
                Console.WriteLine($"Name ={i.name}\nVolume={i.volume}\nPrice={i.price}\n**********");
                Console.WriteLine($"Total value of {i.name} share is {i.volume * i.price}\n");

            }
        }
        /// <summary>
        /// Calculate values for all user stocks
        /// </summary>
        /// <param name="stockList"></param>
        public void CalculateValueOfAllStocks(List<StocksUtility.UserStocks> stockList)
        {
            Console.WriteLine("***********TOTAL VALUE OF ALL USER STOCK***********");
            int totalShareOfCompanies = 0;
            int valueOfEachCompany;
            // StocksUtility.Stocks su = new StocksUtility.Stocks();
            foreach (StocksUtility.UserStocks i in stockList)
            {
                Console.WriteLine($"Name ={i.name}\nVolume={i.volume}\nPrice={i.price}\n***********");
                valueOfEachCompany = i.volume * i.price;
                Console.WriteLine($"Total value of {i.name} share is {valueOfEachCompany}");
                totalShareOfCompanies += valueOfEachCompany;

            }
            Console.WriteLine("***********Total Values Of all Shares***********");
            Console.WriteLine($"Total Value of all shares is {totalShareOfCompanies}");
        }
        /// <summary>
        /// method for buying stocks
        /// </summary>
        /// <param name="jsonFilePathOfStocks"></param>
        public void BuyStocks(string jsonFilePathOfStocks)
        {
            
            StocksUtility utilityOfStockList = JsonConvert.DeserializeObject<StocksUtility>(File.ReadAllText(jsonFilePathOfStocks));
            
            
            //*************************************************************************************************
            DisplayStocks(utilityOfStockList.stockList);
            DisplayStocks(utilityOfStockList.userStockList);
            Console.WriteLine("Enter the name of the stock you want to buy:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter how many volumes you want to buy:");
            int volume = Convert.ToInt32(Console.ReadLine());
            bool check = CheckAvailablity(name, volume, utilityOfStockList.stockList);
            if (check)
            {
                
                StocksUtility.Stocks result = utilityOfStockList.stockList.Find(item => item.name.Equals(name));
                result.volume -= volume;
                Console.WriteLine(result.volume);
                StocksUtility.UserStocks user = new StocksUtility.UserStocks();
                user.name = name;
                user.volume = volume;
                user.price = result.price;
                if(CheckExists(utilityOfStockList.userStockList,user.name))
                {
                    //StocksUtility.UserStocks res = utilityOfStockList.userStockList.Find(item => item.name.Equals(user.name));
                    foreach (StocksUtility.UserStocks i in utilityOfStockList.userStockList)
                    {
                        if (i.name.Equals(name) && i.volume >= volume)
                        {
                            i.volume += user.volume;
                            
                        }
                    }
                    
                }
                else
                {
                    utilityOfStockList.userStockList.AddLast(user);
                }

                File.WriteAllText(jsonFilePathOfStocks, JsonConvert.SerializeObject(utilityOfStockList));
                Console.WriteLine("********Congratulations*************");
                Console.WriteLine($"You Purchased {user.name} of volume = {user.volume} , worth = {user.volume * user.price} ");


            }
            else
            {
                Console.WriteLine(" Stock Not available");
            }

            
        }
        //**********************************************SELL STOCKS*************************************************************
       /// <summary>
       /// Method for selling stocks
       /// </summary>
       /// <param name="jsonFilePathOfStocks"></param>
        public void SellStocks(string jsonFilePathOfStocks)
        {

            StocksUtility utilityOfStockList = JsonConvert.DeserializeObject<StocksUtility>(File.ReadAllText(jsonFilePathOfStocks));

           
            //*************************************************************************************************
            DisplayStocks(utilityOfStockList.userStockList);
            Console.WriteLine("Enter the name of the stock you want to Sell:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter how many volumes you want to Sell:");
            int volume = Convert.ToInt32(Console.ReadLine());
            bool check = CheckAvailablity(name, volume, utilityOfStockList.userStockList);
            if (check)
            {
                StocksUtility.Stocks user = new StocksUtility.Stocks();
                //StocksUtility.UserStocks result = utilityOfStockList.userStockList.Find(item => item.name.Equals(name));
                foreach (StocksUtility.UserStocks i in utilityOfStockList.userStockList)
                {
                    if (i.name.Equals(name) && i.volume >= volume)
                    {
                        i.volume -= volume;
                        user.price = i.price;
                    }
                }
                
                //Console.WriteLine(result.volume);
                
                user.name = name;
                user.volume = volume;
                
                if (CheckExists(utilityOfStockList.stockList, user.name))
                {
                    StocksUtility.Stocks res = utilityOfStockList.stockList.Find(item => item.name.Equals(user.name));
                    res.volume += user.volume;
                }
                else
                {
                    utilityOfStockList.stockList.Add(user);
                }

                File.WriteAllText(jsonFilePathOfStocks, JsonConvert.SerializeObject(utilityOfStockList));
                Console.WriteLine("********Congratulations*************");
                Console.WriteLine($"You Sold {user.name} of volume = {user.volume} , worth = {user.volume * user.price} ");


            }
            else
            {
                Console.WriteLine("Enough Stock Not available to sell");
            }


        }

        //***********************CHECK AVAILABLITY OF STOCKS IN STOCK MARKET*******************
        /// <summary>
        /// check availablity of stock to buy
        /// </summary>
        /// <param name="nameOfStock"></param>
        /// <param name="volumeOfStock"></param>
        /// <param name="stockList"></param>
        /// <returns></returns>
        public bool CheckAvailablity(string nameOfStock,int volumeOfStock, List<StocksUtility.Stocks> stockList)
        {
            StocksUtility.Stocks result =  stockList.Find(item => item.name.Equals(nameOfStock));
            if(result.name.Equals(nameOfStock) && result.volume >= volumeOfStock)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //**********************CHECK AVAILABLITY OF USER STOCKS************************************
        /// <summary>
        /// check availablity of stock to Sell
        /// </summary>
        /// <param name="nameOfStock"></param>
        /// <param name="volumeOfStock"></param>
        /// <param name="stockList"></param>
        /// <returns></returns>
        public bool CheckAvailablity(string nameOfStock, int volumeOfStock, LinkedList<StocksUtility.UserStocks> stockList)
        {
            //StocksUtility.UserStocks result = stockList.Find(item => item.name.Equals(nameOfStock));
            foreach(StocksUtility.UserStocks i in stockList)
            {
                if (i.name.Equals(nameOfStock) && i.volume >= volumeOfStock)
                {
                    return true;
                }
            }
            return false;
        }
        //*************************************CHECK EXISTS FOR STOCKS IN USER STOCKS************
        /// <summary>
        /// check whether stock already exists in user list
        /// </summary>
        /// <param name="stockList"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool CheckExists(LinkedList<StocksUtility.UserStocks> stockList,string name)
        {
            foreach (StocksUtility.UserStocks i in stockList)
            {
                if (i.name.Equals(name))
                {
                    return true;
                }
            }
            return false;
        }
        //***********************CHECK EXISTS FOR STOCKS IN STOCK MARKET********************
        /// <summary>
        /// check whether stock already exists in stocks list
        /// </summary>
        /// <param name="stockList"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool CheckExists(List<StocksUtility.Stocks> stockList, string name)
        {
            foreach (StocksUtility.Stocks i in stockList)
            {
                if (i.name.Equals(name))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
