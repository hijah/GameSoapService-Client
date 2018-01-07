using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using GameStorelibrary;

namespace GameStoreWcfSoap
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        private static List<Games> gameList = new List<Games>()
        {
            new Games(1, "Overwatch", 59.95, 10),
            new Games(2, "Dunkey kong", 4.95, 15),
            new Games(3, "Life is feudal", 24.95, 200)
        };


        public void AddGame(int id, string title, double price, int antalPåLager)
        {
            gameList.Add(new Games(id,title,price,antalPåLager));
        }

        public void DeleteGame(int id)
        {
            var deleteGame = GetOneGame(id.ToString());
            if (deleteGame != null)
            {
                gameList.Remove(deleteGame);
            }
        }

        public List<Games> GetAllGames()
        {
            return gameList;
        }

        public Games GetOneGame(string id)
        {
            int dint = Int32.Parse(id);

            return gameList.Find(c => c.Id == dint);
        }

        public void UpdateGame(int id, string title, int antalPåLager, double price)
        {
            var updateGame = GetOneGame(id.ToString());
            if (updateGame != null)
            {
                updateGame.Title = title;
                updateGame.AntalPåLager = antalPåLager;
                updateGame.Price = price;
            }
        }
    }
}
