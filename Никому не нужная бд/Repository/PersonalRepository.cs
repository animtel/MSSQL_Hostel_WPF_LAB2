using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Dapper;


namespace Никому_не_нужная_бд.Repository
{
    class PersonalRepository
    {
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Cafe.mdf;Integrated Security=True;Connect Timeout=30";
        

        public IEnumerable<Personal> GetItemList()
        {
            //return _db.Books;
            var books = new List<Personal>();
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                books = db.Query<Personal>("SELECT * FROM Personal").ToList();
            }
            return books;
        }

        public Personal GetItem(int id)
        {
            Personal book = null;
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                book = db.Query<Personal>("SELECT * FROM Personal WHERE Id = @id", new { id }).FirstOrDefault();
            }
            return book;
        }

        public void Create(Personal book)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "INSERT INTO Personal VALUES(@FIO, @iD_pers, @id_position, @age)";
                int bookId = db.Query<int>(sqlQuery, book).FirstOrDefault();
                
            }

        }

        public void Update(Personal book)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "UPDATE Personal SET FIO = @FIO, iD_pers = @iD_pers, id_position = @id_position, age = @age WHERE iD_pers = @iD_pers";
                db.Execute(sqlQuery, book);
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "DELETE FROM Personal WHERE iD_pers = @iD_pers";
                db.Execute(sqlQuery, new { id });
            }


        }

        
    }
}
