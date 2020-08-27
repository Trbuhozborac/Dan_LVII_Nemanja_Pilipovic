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

        [OperationContract]
        void WriteBillToTxtFile(string bill);

    }    
}
