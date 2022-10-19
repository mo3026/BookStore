using System;
using System.Data.SqlClient;
using BookStore.Model;
using System.Linq;
using System.Data;
using System.Collections.Generic;

namespace BookStore.DBActions
{
    public class BooksActions
    {
        static SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-CM3DQK7\SQLEXPRESS;Initial Catalog=master;Integrated Security=True");

        public static List<Book> BookSelect()
        {
            List<Book> Books = new List<Book>();
            try
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.Connection = con;
                cmd.CommandText = "BooksGetInsertUpdateDelete";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@bookID", 0);
                cmd.Parameters.AddWithValue("@title", "");
                cmd.Parameters.AddWithValue("@price", 0);
                cmd.Parameters.AddWithValue("@genre", "");
                cmd.Parameters.AddWithValue("@publisherID", 1);
                cmd.Parameters.AddWithValue("@statementtype", "select");
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Books.Add(new Book()
                    {
                        BookID = int.Parse(reader["BookID"].ToString()),
                        Title = reader["Title"].ToString(),
                        Price = decimal.Parse(reader["Price"].ToString()),
                        Genre = reader["Genre"].ToString(),
                        PublisherID = int.Parse(reader["PublisherID"].ToString()),
                    });
                }
                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return Books;
        }

        public static List<Book> BookSearch(string columnName, string value)
        {
            List<Book> Books = new List<Book>();
            try
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.Connection = con;
                cmd.CommandText = "BooksSearch";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@columnName", columnName);
                cmd.Parameters.AddWithValue("@value", value);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Books.Add(new Book()
                    {
                        BookID = int.Parse(reader["BookID"].ToString()),
                        Title = reader["Title"].ToString(),
                        Price = decimal.Parse(reader["Price"].ToString()),
                        Genre = reader["Genre"].ToString(),
                        PublisherID = int.Parse(reader["PublisherID"].ToString()),
                    });
                }
                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return Books;
        }

        public Book BookGet(int BookID, out string message)
        {
            Book book = null;
            message= "Success";
            try
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.Connection = con;
                cmd.CommandText = "BooksGetInsertUpdateDelete";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@bookID", BookID);
                cmd.Parameters.AddWithValue("@title", "");
                cmd.Parameters.AddWithValue("@price", 0);
                cmd.Parameters.AddWithValue("@genre", "");
                cmd.Parameters.AddWithValue("@publisherID", 1);
                cmd.Parameters.AddWithValue("@statementtype", "get");
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                book = new Book()
                {
                    Title = reader["Title"].ToString(),
                    Price = decimal.Parse(reader["Price"].ToString()),
                    Genre = reader["Genre"].ToString(),
                    PublisherID = int.Parse(reader["PublisherID"].ToString()),
                };
                con.Close();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return book;
        }

        public string BookInsert(Book book)
        {
            string message = "Success";
            try
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.Connection = con;
                cmd.CommandText = "BooksGetInsertUpdateDelete";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@bookID", 0);
                cmd.Parameters.AddWithValue("@title", book.Title);
                cmd.Parameters.AddWithValue("@price", book.Price);
                cmd.Parameters.AddWithValue("@genre", book.Genre);
                cmd.Parameters.AddWithValue("@publisherID", book.PublisherID);
                cmd.Parameters.AddWithValue("@statementtype", "insert");
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return message;
        }

        public string BookUpdate(Book book)
        {
            string message = "Success";
            try
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.Connection = con;
                cmd.CommandText = "BooksGetInsertUpdateDelete";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@bookID", book.BookID);
                cmd.Parameters.AddWithValue("@title", book.Title);
                cmd.Parameters.AddWithValue("@price", book.Price);
                cmd.Parameters.AddWithValue("@genre", book.Genre);
                cmd.Parameters.AddWithValue("@publisherID", book.PublisherID);
                cmd.Parameters.AddWithValue("@statementtype", "update");
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return message;
        }

        public string BookDelete(int BookID)
        {
            string message = "Success";
            try
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.Connection = con;
                cmd.CommandText = "BooksGetInsertUpdateDelete";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@bookID", BookID);
                cmd.Parameters.AddWithValue("@title", "");
                cmd.Parameters.AddWithValue("@price", 0);
                cmd.Parameters.AddWithValue("@genre", "");
                cmd.Parameters.AddWithValue("@publisherID", 0);
                cmd.Parameters.AddWithValue("@statementtype", "delete");
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return message;
        }
    }
}
