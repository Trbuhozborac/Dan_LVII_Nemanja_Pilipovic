namespace Zadatak_1.Models
{
    class Item
    {
        #region Properties

        public int Id { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public int Price { get; set; }

        #endregion

        #region Constructors

        public Item()
        {

        }

        public Item(string name, int amount, int price)
        {
            Name = name;
            Amount = amount;
            Price = price;
        }

        #endregion
    }
}
