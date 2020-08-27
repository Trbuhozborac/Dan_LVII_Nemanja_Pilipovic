using System;
using System.IO;
using System.Runtime.InteropServices;

namespace Zadatak_1_Service
{
    public class Service1 : IService1
    {
        public void AddNewItem(string item)
        {
            try
            {
                string _loaction = @"~/../../../Items.txt";

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
          
        }       
    }
}
