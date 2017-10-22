using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Dapper;
/// <summary>
/// Summary description for Class1
/// </summary>
/// 
namespace Никому_не_нужная_бд.Repository
{
    public class Position
    {
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Cafe.mdf;Integrated Security=True;Connect Timeout=30";


        public IEnumerable<Position> GetItemList()
        {
            //return _db.Books;
            var books = new List<Position>();
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                books = db.Query<Position>("SELECT * FROM Position").ToList();
            }
            return books;
        }

        public Position GetItem(int id)
        {
            Position book = null;
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                book = db.Query<Position>("SELECT * FROM Personal WHERE id_position = @id", new { id }).FirstOrDefault();
            }
            return book;
        }

        public void Create(Position book)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "INSERT INTO Position VALUES(@time, @iD_pers, @last_bludo)";
                int bookId = db.Query<int>(sqlQuery, book).FirstOrDefault();

            }

        }

        public void Update(Position book)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "UPDATE Position SET time = @time, iD_pers = @iD_pers, last_bludo = @last_bludo WHERE id_position = @id_position";
                db.Execute(sqlQuery, book);
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "DELETE FROM Position WHERE id_position  = @id";
                db.Execute(sqlQuery, new { id });
            }



        }
    }
}