using System;
using System.Threading;

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
                        Console.WriteLine("All Items");
                        break;
                    case 2:
                        Console.WriteLine("Price Modification");
                        break;
                    case 3:
                        Console.WriteLine("Add New Item");
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

        #endregion

    }
}
