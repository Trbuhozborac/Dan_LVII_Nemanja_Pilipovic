using System.Runtime.Serialization;
using System.ServiceModel;

namespace Zadatak_1_Service
{
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        void GetAllItems();

        [OperationContract]
        void AddNewItem(string item);
       
    }
    [DataContract]
    public class Item
    {
        private string name;
        private int amount;
        private int price;

        [DataMember]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        [DataMember]
        public int Amount
        {
            get { return amount; }
            set { amount = value; }
        }

        [DataMember]
        public int Price
        {
            get { return price; }
            set { price = value; }
        }
    }

}
