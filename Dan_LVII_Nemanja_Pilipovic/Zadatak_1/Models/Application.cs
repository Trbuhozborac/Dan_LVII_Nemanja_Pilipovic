using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
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
            Console.WriteLine("2) Add new Item");
            Console.WriteLine("3) Item price modification");
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
                        AddNewItem();
                        ReturnAfterAction();
                        break;
                    case 3:
                        ModifyItemPrice();
                        ReturnAfterAction();
                        break;
                    case 4:
                        BuyItems();
                        ReturnAfterAction();
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
            
            string itemInfo = "\n" + item.Id + "," + item.Name + "," + item.Amount + "," + item.Price;
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


        private void ModifyItemPrice()
        {
            Service1 s = new Service1();
            
            List<Item> allItems = GetListOfAllItems();
            foreach (Item item in allItems)
            {
                Console.WriteLine(item.Id + ")" + " Name: " + item.Name + " Amount: " + item.Amount + " Price: " + item.Price + "$");
            }

            Item foundedItem = GetMatch(allItems);
            if(foundedItem != null)
            {
                foundedItem.Price = GetItemPrice();
                Console.WriteLine("Item Price Updated Successfully!");
            }

            WriteListToTxtFile(allItems);

        }

        private void WriteListToTxtFile(List<Item> allItems)
        {
            string _loaction = @"~/../../../Items.txt";

            try
            {
                if (File.Exists(_loaction))
                {
                    File.WriteAllText(_loaction, "");
                    foreach (Item item in allItems)
                    {
                        string allInfoAboutItem = "\n" + item.Id + "," + item.Name + "," + item.Amount + "," + item.Price;
                        File.AppendAllText(_loaction, allInfoAboutItem);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        private Item GetMatch(List<Item> allItems)
        {
            Console.WriteLine("Enter Id of the Item witch Price you want to modify <Enter 0 to go back>:");
            Item foundedItem = new Item();
            int id = GetItemId();
            for (int i = 0; i < allItems.Count; i++)
            {
                if(allItems[i].Id == id)
                {
                    foundedItem = allItems[i];
                    break;
                }
                else if(allItems[i] == allItems[allItems.Count - 1])
                {
                    Console.WriteLine("There is no Item with that Id");
                    return GetMatch(allItems);
                }
                else
                {
                    continue;
                }
            }

            return foundedItem;
        }

        private int GetItemId()
        {
            string choosenId = Console.ReadLine();
            if(int.TryParse(choosenId, out int id))
            {
                if(id < 0)
                {
                    Console.WriteLine("Please enter a positive number");
                    return GetItemId();
                }
                else if (id == 0)
                {
                    Application app = new Application();
                    app.Start();
                    return 0;
                }
                else
                {
                    return id;
                }
            }
            else
            {
                Console.WriteLine("Please enter a number");
                return GetItemId();
            }
        }

        private List<Item> GetListOfAllItems()
        {
            string _loaction = @"~/../../../Items.txt";

            List<Item> items = new List<Item>();
            try
            {
                if (File.Exists(_loaction))
                {
                    string[] allItems = File.ReadAllLines(_loaction);
                    Console.WriteLine("All items:");
                    foreach (string item in allItems)
                    {
                        if (item != "")
                        {
                            string[] allInfo = item.Split(',');
                            string id = allInfo[0];
                            string name = allInfo[1];
                            string amount = allInfo[2];
                            string price = allInfo[3];

                            Item existingItem = new Item(Convert.ToInt32(id), name, Convert.ToInt32(amount), Convert.ToInt32(price));
                            items.Add(existingItem);
                        }
                        else
                        {
                            continue;
                        }
                    }
                    return items;
                }
                else
                {
                    Console.WriteLine("File not found");
                    return null;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return null;
            }
        }

        private void BuyItems()
        {
            List<Item> allItems = GetListOfAllItems();
            foreach (Item item in allItems)
            {
                Console.WriteLine(item.Id + ")" + " Name: " + item.Name + " Amount: " + item.Amount + " Price: " + item.Price + "$");
            }

            Bill bill = new Bill();
            bill.Items = new List<Item>();

            bool _exit = true;
            do
            {

                Console.WriteLine("Enter Id of the Item witch you want to buy <Enter 0 to go back>:");
                Item foundedItem = new Item();
                foundedItem = GetMatchBuy(allItems);
                int amount = AmountOfItem(foundedItem);
                foundedItem.Amount -= amount;
                Console.WriteLine("Item Buyed Successfully!");

                Random r = new Random();
                bill.Id = r.Next(0, 1000);
                bill.DateOfCreating = DateTime.Now;
                
               

                bill.Items.Add(foundedItem);

                bool continueBuy = ContinueBuying();
                if(continueBuy == true)
                {
                    continue;
                }
                else
                {
                    int totalAmount = 0;
                    foreach (Item item in bill.Items)
                    {
                        totalAmount += item.Price;
                    }

                    bill.TotalAmount = totalAmount;
                    WriteListToTxtFile(allItems);
                    string date = bill.DateOfCreating.ToShortDateString();
                    string allItemsInfo = "";
                    foreach (Item item in bill.Items)
                    {
                        allItemsInfo +=  item.Name + " To Pay: " + item.Amount * item.Price + "$ ";
                    }
                    string price = bill.TotalAmount.ToString();

                    string allInfo = "Date: " + date + ", Items: " + allItemsInfo + ", Total Amount: " + price + "$";

                    Service1 s = new Service1();
                    s.WriteBillToTxtFile(allInfo);
                    Console.WriteLine("Buy Confirmed Successfully!");
                    _exit = false;
                }

            } while (_exit);
        }

        private Item GetMatchBuy(List<Item> allItems)
        {
            Item foundedItem = new Item();
            int id = GetItemId();
            for (int i = 0; i < allItems.Count; i++)
            {
                if (allItems[i].Id == id)
                {
                    foundedItem = allItems[i];
                    break;
                }
                else if (allItems[i] == allItems[allItems.Count - 1])
                {
                    Console.WriteLine("There is no Item with that Id");
                    return GetMatch(allItems);
                }
                else
                {
                    continue;
                }
            }

            return foundedItem;
        }

        private int AmountOfItem(Item foundedItem)
        {
            Console.WriteLine("How much {0} you want to buy? <Enter 0 to go back>", foundedItem.Name);
            string amountString = Console.ReadLine();
            if(int.TryParse(amountString, out int amount))
            {
                if(amount < 0)
                {
                    Console.WriteLine("Please enter a positive number");
                    return AmountOfItem(foundedItem);
                }
                else if(amount == 0)
                {
                    Application app = new Application();
                    app.Start();
                    return 0;
                }
                else if(amount > foundedItem.Amount)
                {
                    Console.WriteLine("There is no enough amount");
                    return AmountOfItem(foundedItem);
                }
                else
                {
                    return amount;
                }
            }
            else
            {
                Console.WriteLine("Please enter a number");
                return AmountOfItem(foundedItem);
            }
        }

        private bool ContinueBuying()
        {
            Console.WriteLine("Continue buying? <Y/N>");
            string answer = Console.ReadLine();
            if (answer == "Y" || answer == "y")
            {
                return true;
            }
            else if (answer == "N" || answer == "n")
            {
                return false;
            }
            else
            {
                Console.WriteLine("Please enter Y or N");
                return ContinueBuying();
            }
        }

        #endregion

    }
}

