using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameStoreClientSoap.ServiceReference1;

namespace GameStoreClientSoap
{
    class SoapClient
    {
        public SoapClient()
        {
            
        }

        public void Start()
        {
            using (var client = new ServiceReference2.Service1Client("BasicHttpBinding_IService11"))
            {
                Console.WriteLine("All games \n");
                foreach (var games in client.GetAllGames())
                {
                    Console.WriteLine("Game Id: " + games.Id + " Game Title: " + games.Title + " Game Price: " + games.Price + " Stock of game: " + games.AntalPåLager);
                    
                }

                var game = client.GetOneGame("1");

                Console.WriteLine("\n Game with id = 1 " + "Game Id: " + game.Id + " Game Title: " + game.Title + " Game Price: " + game.Price + " Stock of game: " + game.AntalPåLager);

                client.UpdateGame(1, "Mario", 55, 5.95);

                Console.ReadKey();

                Console.WriteLine("\n After updating \n ");

                foreach (var games in client.GetAllGames())
                {
                    Console.WriteLine("Game Id: " + games.Id + " Game Title: " + games.Title + " Game Price: " + games.Price + " Stock of game: " + games.AntalPåLager);
                    
                }

                client.AddGame(4, "7 days to die", 19.95, 500);

                Console.ReadKey();

                Console.WriteLine("\n After Added game \n");

                foreach (var games in client.GetAllGames())
                {
                    Console.WriteLine("Game Id: " + games.Id + " Game Title: " + games.Title + " Game Price: " + games.Price + " Stock of game: " + games.AntalPåLager);
                    
                }
                client.DeleteGame(1);

                Console.ReadKey();

                Console.WriteLine("\n After Deleting game with id = 1 \n");

                foreach (var games in client.GetAllGames())
                {
                    Console.WriteLine("Game Id: " + games.Id + " Game Title: " + games.Title + " Game Price" + games.Price + " Stock of game: " + games.AntalPåLager);
                    
                }
            }
        }

    }
}
