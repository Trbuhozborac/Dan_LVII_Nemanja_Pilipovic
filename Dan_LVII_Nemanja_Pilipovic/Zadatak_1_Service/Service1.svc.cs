using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;

namespace Zadatak_1_Service
{
    public class Service1 : IService1
    {
        private readonly string _loaction = @"~/../../../Items.txt";
        private static int idCounter = 0;

        public void AddNewItem(string item)
        {
            try
            {
                if(item != null)
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
                        if(item != "")
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
    }
}
