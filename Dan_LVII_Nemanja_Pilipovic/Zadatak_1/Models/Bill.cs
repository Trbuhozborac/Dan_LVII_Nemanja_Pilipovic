using System;
using System.Collections.Generic;

namespace Zadatak_1.Models
{
    class Bill
    {
        #region Properties

        public int Id { get; set; }
        public DateTime DateOfCreating { get; set; }
        public List<Item> Items { get; set; }
        public int TotalAmount { get; set; }

        #endregion

        #region Constructors

        public Bill()
        {

        }
        
        #endregion
    }
}
