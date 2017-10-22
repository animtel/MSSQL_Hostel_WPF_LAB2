using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Никому_не_нужная_бд.Models;
using Dapper;

namespace Никому_не_нужная_бд.Repository
{
    class ReceptionRepository
    {
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Cafe.mdf;Integrated Security=True;Connect Timeout=30";


        public IEnumerable<Dishes> GetItemList()
        {
            var books = new List<Dishes>();
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                books = db.Query<Dishes>("SELECT * FROM Dishes").ToList();
            }
            return books;
        }

        public Personal GetItem(int id)
        {
            Personal book = null;
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                book = db.Query<Personal>("SELECT * FROM Dishes WHERE bludo_name = @id", new { id }).FirstOrDefault();
            }
            return book;
        }

        public void Create(Personal book)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "INSERT INTO Personal VALUES(@Name, @Author, @Price, @Year, @Publishing)";
                int bookId = db.Query<int>(sqlQuery, book).FirstOrDefault();

            }

        }

        public void Update(Personal book)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "UPDATE dbo.Books SET Name = @Name, Author = @Author, Publishing = @Publishing, Year = @Year, Price = @Price WHERE Id = @Id";
                db.Execute(sqlQuery, book);
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "DELETE FROM dbo.Books WHERE Id = @id";
                db.Execute(sqlQuery, new { id });
            }


        }
    }
}
