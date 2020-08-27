using System;
using System.Runtime.CompilerServices;
using System.Threading;
using Zadatak_1_Service;

namespace Zadatak_1.Models
{
    class Application
    {
        #region Functions

        public void Start()
        {
            Menu();
        }

        private void Menu()
        {
            Console.WriteLine("Welcome User!");
            Console.WriteLine("Enter one of the numbers from menu:");
            Console.WriteLine("1) Show all Items");
            Console.WriteLine("2) Item price modification");
            Console.WriteLine("3) Add new Item");
            Console.WriteLine("4) Buy");
            Console.WriteLine("0) Close the app");
            string userAnswer = Console.ReadLine();
            if(int.TryParse(userAnswer, out int answer))
            {
                switch (answer)
                {
                    case 1:
                        Service1 s = new Service1();
                        s.GetAllItems();
                        ReturnAfterAction();
                        break;
                    case 2:
                        Console.WriteLine("opa");
                        break;
                    case 3:
                        AddNewItem();
                        ReturnAfterAction();
                        break;
                    case 4:
                        Console.WriteLine("Buy");
                        break;
                    case 0:
                        Console.WriteLine("Closing the app...");
                        Thread.Sleep(2000);
                        break;
                    default:
                        Console.WriteLine("Please enter of the numbers from menu");
                        Menu();
                        break;
                }
            }
            else
            {
                Console.WriteLine("Please enter one of the numbers from menu");
                Menu();
            }
        }

        private void ReturnAfterAction()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
            Menu();
        }

        private void AddNewItem()
        {
            Random r = new Random();
            Item item = new Item();
            item.Name = GetItemName();
            item.Amount = GetItemAmount();
            item.Price = GetItemPrice();
            item.Id = r.Next(0, 1000);
            
            string itemInfo = "\n" + item.Id + item.Name + "," + item.Amount + "," + item.Price;
            Service1 s = new Service1();
            s.AddNewItem(itemInfo);
        }

        private string GetItemName()
        {
            Console.WriteLine("Item Name:");
            string itemName = Console.ReadLine();
            if (string.IsNullOrEmpty(itemName) || string.IsNullOrWhiteSpace(itemName))
            {
                Console.WriteLine("Please enter item name");
                return GetItemName();               
            }
            else
            {
                return itemName;
            }
        }

        private int GetItemAmount()
        {
            Console.WriteLine("Amount:");
            string itemAmount = Console.ReadLine();
            if(int.TryParse(itemAmount, out int amount))
            {
                if(amount <= 0)
                {
                    Console.WriteLine("Please enter positive a number");
                    return GetItemAmount();
                }
                else
                {
                    return amount;
                }
            }
            else
            {
                Console.WriteLine("Please enter a number");
                return GetItemAmount();
            }
        }


        private int GetItemPrice()
        {
            Console.WriteLine("Price:");
            string itemPrice = Console.ReadLine();
            if(int.TryParse(itemPrice, out int price))
            {
                if(price <= 0)
                {
                    Console.WriteLine("Please enter a positive number");
                    return GetItemPrice();
                }
                else
                {
                    return price;
                }
            }
            else
            {
                Console.WriteLine("Please enter a number");
                return GetItemPrice();
            }
        }

        #endregion

    }
}

