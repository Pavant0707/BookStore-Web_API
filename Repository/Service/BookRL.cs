using ModelLayer.BookModel;
using Repository.Context;
using Repository.Entity;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Service
{
    public class BookRL : IBookRL
    {
        private readonly BookContext bookContext;

        public BookRL(BookContext bookContext)
        {
            this.bookContext = bookContext;
        }

        public BookModel AddBook(BookModel model)
        {
            SqlConnection connection = (SqlConnection)bookContext.CreateConnection();
            connection.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("ADDBOOK", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TITLE", model.TITLE);
                cmd.Parameters.AddWithValue("@AUTHOR", model.AUTHOR);
                cmd.Parameters.AddWithValue("@ORIGINALPRICE", model.ORIGINALPRICE);
                cmd.Parameters.AddWithValue("@DISCOUNTPERCENTAGE", model.DISCOUNTPERCENTAGE);
                cmd.Parameters.AddWithValue("@DESCRIPTION", model.DESCRIPTION);
                cmd.Parameters.AddWithValue("@IMAGE", model.IMAGE);
                cmd.Parameters.AddWithValue("@QUANTITY", model.QUANTITY);
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                connection.Close();

            }
            return model;
        }

        public object DeleteBook(int BOOKID)
        {
            SqlConnection connection = (SqlConnection)bookContext.CreateConnection();
            connection.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("DeleteBook", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BOOKID", BOOKID);
                SqlDataReader sdr = cmd.ExecuteReader();

                cmd.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                connection.Close();

            }
            return false;
        }
    

        public object GetBook()
        {
            SqlConnection connection = (SqlConnection)bookContext.CreateConnection();
            connection.Open();

            List<BookEntity> bookEntities = new List<BookEntity>();
            SqlCommand cmd = new SqlCommand("GetAllBooks", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader sdr = cmd.ExecuteReader();

            while (sdr.Read())
            {
                BookEntity book = new BookEntity();
                book.BOOKID = Convert.ToInt32(sdr["BOOKID"]);
                book.TITLE= sdr["TITLE"].ToString();
                book.AUTHOR = sdr["AUTHOR"].ToString();
                //book.RATING = Convert.ToInt32(sdr["RATING"]);
                book.RATING = sdr.IsDBNull(sdr.GetOrdinal("RATING")) ? 0.0f : Convert.ToSingle(sdr["RATING"]);
                //book.RATINGCOUNT =Convert.ToInt32(sdr["RATINGCOUNT"]);
                book.RATINGCOUNT = sdr.IsDBNull(sdr.GetOrdinal("RATINGCOUNT")) ? 0 : Convert.ToInt32(sdr["RATINGCOUNT"]);
                book.PRICE = Convert.ToInt32(sdr["PRICE"]);
                book.ORIGINALPRICE = Convert.ToInt32(sdr["ORIGINALPRICE"]);
                //book.DISCOUNTPERCENTAGE = Convert.ToInt32(["DISCOUNTPERCENTAGE"]);
                book.DESCRIPTION = sdr["DESCRIPTION"].ToString();
                book.IMAGE = sdr["IMAGE"].ToString();
                book.QUANTITY = Convert.ToInt32(sdr["QUANTITY"]);

                bookEntities.Add(book);

            }
            connection.Close();
            return bookEntities;
            

        }

        public object GetBookById(int BOOKID)
        {
            SqlConnection connection = (SqlConnection)bookContext.CreateConnection();
            connection.Open();
            List<BookEntity> bookEntities = new List<BookEntity>();
            SqlCommand cmd = new SqlCommand("GetBookByID", connection);
            cmd.Parameters.AddWithValue("@BOOKID",BOOKID);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader sdr = cmd.ExecuteReader();

            while (sdr.Read())
            {
                BookEntity book = new BookEntity();
                book.BOOKID = Convert.ToInt32(sdr["BOOKID"]);
                book.TITLE = sdr["TITLE"].ToString();
                book.AUTHOR = sdr["AUTHOR"].ToString();
                //book.RATING = Convert.ToInt32(sdr["RATING"]);
                book.RATING = sdr.IsDBNull(sdr.GetOrdinal("RATING")) ? 0.0f : Convert.ToSingle(sdr["RATING"]);
                //book.RATINGCOUNT =Convert.ToInt32(sdr["RATINGCOUNT"]);
                book.RATINGCOUNT = sdr.IsDBNull(sdr.GetOrdinal("RATINGCOUNT")) ? 0 : Convert.ToInt32(sdr["RATINGCOUNT"]);
                book.PRICE = Convert.ToInt32(sdr["PRICE"]);
                book.ORIGINALPRICE = Convert.ToInt32(sdr["ORIGINALPRICE"]);
                //book.DISCOUNTPERCENTAGE = Convert.ToInt32(["DISCOUNTPERCENTAGE"]);
                book.DESCRIPTION = sdr["DESCRIPTION"].ToString();
                book.IMAGE = sdr["IMAGE"].ToString();
                book.QUANTITY = Convert.ToInt32(sdr["QUANTITY"]);

                bookEntities.Add(book);

            }
            connection.Close();
            return bookEntities;
        }

        public object GetBookByName(string TITLE, string AUTHOR)
        {
            SqlConnection connection = (SqlConnection)bookContext.CreateConnection();
            connection.Open();
            List<BookEntity> bookEntities = new List<BookEntity>();
            SqlCommand cmd = new SqlCommand("GetBookByName", connection);
            cmd.Parameters.AddWithValue("@TITLE",TITLE);
            cmd.Parameters.AddWithValue("@AUTHOR",AUTHOR);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader sdr = cmd.ExecuteReader();

            while (sdr.Read())
            {
                BookEntity book = new BookEntity();
                book.BOOKID = Convert.ToInt32(sdr["BOOKID"]);
                book.TITLE = sdr["TITLE"].ToString();
                book.AUTHOR = sdr["AUTHOR"].ToString();
                book.RATING = sdr.IsDBNull(sdr.GetOrdinal("RATING")) ? 0.0f : Convert.ToSingle(sdr["RATING"]);
                book.RATINGCOUNT = sdr.IsDBNull(sdr.GetOrdinal("RATINGCOUNT")) ? 0 : Convert.ToInt32(sdr["RATINGCOUNT"]);
                book.PRICE = Convert.ToInt32(sdr["PRICE"]);
                book.ORIGINALPRICE = Convert.ToInt32(sdr["ORIGINALPRICE"]);
                book.DESCRIPTION = sdr["DESCRIPTION"].ToString();
                book.IMAGE = sdr["IMAGE"].ToString();
                book.QUANTITY = Convert.ToInt32(sdr["QUANTITY"]);

                bookEntities.Add(book);

            }
            connection.Close();
            return bookEntities;
        }

        public object UpdateBook(int BOOKID, BookModel model)
        {
            SqlConnection connection = (SqlConnection)bookContext.CreateConnection();
            connection.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("UpdateBook", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BOOKID",BOOKID);
                cmd.Parameters.AddWithValue("@TITLE", model.TITLE);
                cmd.Parameters.AddWithValue("@AUTHOR", model.AUTHOR);
                cmd.Parameters.AddWithValue("@ORIGINALPRICE", model.ORIGINALPRICE);
                cmd.Parameters.AddWithValue("@DISCOUNTPERCENTAGE", model.DISCOUNTPERCENTAGE);
                cmd.Parameters.AddWithValue("@DESCRIPTION", model.DESCRIPTION);
                cmd.Parameters.AddWithValue("@IMAGE", model.IMAGE);
                cmd.Parameters.AddWithValue("@QUANTITY", model.QUANTITY);
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                connection.Close();

            }
            return model;
        }
    }
}
