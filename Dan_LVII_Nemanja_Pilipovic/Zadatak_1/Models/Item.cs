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

        public Item(int id,string name, int amount, int price)
        {
            Id = id;
            Name = name;
            Amount = amount;
            Price = price;
        }

        #endregion
    }
}
