using System;
using System.IO;

namespace Zadatak_1_Service
{
    public class Service1 : IService1
    {
        #region Private Fileds

        private readonly string _loaction = @"~/../../../Items.txt";
        private static int idCounter = 0;

        #endregion

        #region Functions

        /// <summary>
        /// Add new Item to the txt file
        /// </summary>
        /// <param name="item">Info about item thats being writed into txt file</param>
        public void AddNewItem(string item)
        {
            try
            {
                if (item != null)
                {
                    if (File.Exists(_loaction))
                    {
                        File.AppendAllText(_loaction, item);
                        Console.WriteLine("Item Added Successfully!");
                    }
                    else
                    {
                        Console.WriteLine("File not found.");
                    }
                }
                else
                {
                    Console.WriteLine("Something went wrong...");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Writes all Items from txt file
        /// </summary>
        public void GetAllItems()
        {
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

                            Console.WriteLine(id + ")" + " Name: " + name + " Amount: " + amount + " Price: " + price + "$");
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("File not found");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Writes Info about bill into txt file
        /// </summary>
        /// <param name="bill"></param>
        public void WriteBillToTxtFile(string bill)
        {
            try
            {
                string path = @"~/../../../Bill_" + idCounter + "_TimeStamp.txt";
                using (FileStream fs = File.Create(path)) { }
                if (File.Exists(path))
                {
                    File.WriteAllText(path, bill);
                    idCounter++;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        #endregion

    }
}
