using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using GameStorelibrary;

namespace GameStoreWcfSoapDB
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        private static string connectionString = "Server=tcp:databasejacob.database.windows.net,1433;Initial Catalog=Jacob'sDatabase;Persist Security Info=False;User ID=hijah;Password=Camilla10;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        #region Get
        public List<Games> GetAllGames()
        {
            List<Games> liste = new List<Games>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                String sql = "SELECT * FROM dbo.GameStore";
                SqlCommand command = new SqlCommand(sql, conn);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Games games = new Games();

                    games.Id = reader.GetInt32(0);
                    games.Title = reader.GetString(1);
                    games.Price = (double) reader.GetDecimal(2);
                    games.AntalPåLager = reader.GetInt32(3);

                    liste.Add(games);
                }
            }
            return liste;
        }
        #endregion

        #region Get One Game
        public Games GetOneGame(string id)
        {
            Games game = new Games();
            int idint = Convert.ToInt32(id);
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                String sql = "SELECT * FROM dbo.GameStore WHERE Id = @id";
                SqlCommand command = new SqlCommand(sql, conn);
                command.Parameters.AddWithValue("@id", idint);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    game.Id = reader.GetInt32(0);
                    game.Title = reader.GetString(1);
                    game.Price = (double) reader.GetDecimal(2);
                    game.AntalPåLager = reader.GetInt32(3);
                }
                return game;
            }
        }
        #endregion

        #region Delete
        public void DeleteGame(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                String sql = @"DELETE FROM dbo.GameStore WHERE Id = @id";
                SqlCommand command = new SqlCommand(sql, conn);
                command.Parameters.AddWithValue("@id", id);

                command.ExecuteNonQuery();
                conn.Close();
            }
        }
        #endregion

        #region Put
        public void UpdateGame(int id, string title, int AntalPåLager, double Price)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                String sql = @"UPDATE dbo.GameStore SET Title = @Title, Price = @Price, AntalPåLager = @AntalPåLager WHERE Id = @id";
                SqlCommand command = new SqlCommand(sql, conn);
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@Title", title);
                command.Parameters.AddWithValue("@Price", Price);
                command.Parameters.AddWithValue("@AntalPåLager", AntalPåLager);

                command.ExecuteNonQuery();
                conn.Close();
            }
        }
        #endregion

        #region Post
        public void AddGame(int id, string title, double price, int antalPåLager)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                String sql = @"INSERT INTO dbo.GameStore(Id, Title, Price, AntalPåLager) VALUES (@Id, @Title, @Price, @AntalPåLager)";
                SqlCommand command = new SqlCommand(sql, conn);
                command.Parameters.AddWithValue("@Id",id);
                command.Parameters.AddWithValue("@Title",title);
                command.Parameters.AddWithValue("@Price",price);
                command.Parameters.AddWithValue("@AntalPåLager",antalPåLager);

                command.ExecuteNonQuery();
                conn.Close();
            }
        }
        #endregion
    }
}
