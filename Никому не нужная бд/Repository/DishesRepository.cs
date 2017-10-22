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
namespace Никому_не_нужная_бд.Repository
{
    public class Dishes
    {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Cafe.mdf;Integrated Security=True;Connect Timeout=30";


            public IEnumerable<Dishes> GetItemList()
            {
                //return _db.Books;
                var books = new List<Dishes>();
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    books = db.Query<Dishes>("SELECT * FROM Dishes").ToList();
                }
                return books;
            }

            public Dishes GetItem(string id)
            {
                Dishes book = null;
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    book = db.Query<Dishes>("SELECT * FROM Dishes WHERE bludo_name = @id", new { id }).FirstOrDefault();
                }
                return book;
            }

            public void Create(Dishes book)
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    var sqlQuery = "INSERT INTO Dishes VALUES(@Bludo_name, @Cost)";
                    int bookId = db.Query<int>(sqlQuery, book).FirstOrDefault();

                }

            }

            public void Update(Dishes book)
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    var sqlQuery = "UPDATE Dishes SET  Cost = @Cost WHERE Bludo_name = @Bludo_name";
                    db.Execute(sqlQuery, book);
                }
            }

            public void Delete(string id)
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    var sqlQuery = "DELETE FROM Dishes WHERE Bludo_name = @id";
                    db.Execute(sqlQuery, new { id });
                }


            }

        
    }

}