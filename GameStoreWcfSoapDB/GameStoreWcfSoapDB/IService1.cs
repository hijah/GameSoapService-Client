using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using GameStorelibrary;

namespace GameStoreWcfSoapDB
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        List<Games> GetAllGames();

        [OperationContract]
        Games GetOneGame(string id);

        [OperationContract]
        void DeleteGame(int id);

        [OperationContract]
        void UpdateGame(int id, string title, int AntalPåLager, double Price);

        [OperationContract]
        void AddGame(int id, string title, double price, int antalPåLager);
    }
}
