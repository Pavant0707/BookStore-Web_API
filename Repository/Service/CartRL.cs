using ModelLayer.BookModel;
using Repository.Context;
using Repository.Entity;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ModelLayer.CartModel;
using ModelLayer.UserModel;

namespace Repository.Service
{
    public class CartRL : ICartRL
    {
        private readonly BookContext bookContext;

        public CartRL(BookContext bookContext)
        {
            this.bookContext = bookContext;
        }

        public List<BookEntity> AddCart(CartModel model,int USERID)
        {
            SqlConnection connection = (SqlConnection)bookContext.CreateConnection();
            connection.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("AddBookToCart", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@USERID", USERID);
                cmd.Parameters.AddWithValue("@BOOKID", model.BOOKID);
                cmd.Parameters.AddWithValue("@Quantity", model.Quantity);
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
            return GetCartItems(USERID);
        }

        public object deleteCart(int CartId)
        {
            SqlConnection connection = (SqlConnection)bookContext.CreateConnection();
            connection.Open();
            List<CartEntity> bookEntities = new List<CartEntity>();
            SqlCommand cmd = new SqlCommand("DELETEBYID", connection);
            cmd.Parameters.AddWithValue("@CartId", CartId);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader sdr = cmd.ExecuteReader();

            while (sdr.Read())
            {
                //BookEntity book = new BookEntity();
                CartEntity book = new CartEntity();
                book.BOOKID = Convert.ToInt32(sdr["BOOKID"]);
                book.TITLE = sdr["TITLE"].ToString();
                book.AUTHOR = sdr["AUTHOR"].ToString();
                book.IMAGE = sdr["IMAGE"].ToString();
                book.QUANTITY = Convert.ToInt32(sdr["QUANTITY"]);
                book.FULLNAME = sdr["FULLNAME"].ToString();
                book.PHONENUMBER = sdr["PHONENUMBER"].ToString();
                bookEntities.Add(book);

            }
            connection.Close();
            return bookEntities;
        }

        public List<CartEntity> GetBooks(int USERID)
        {
            SqlConnection connection = (SqlConnection)bookContext.CreateConnection();
            connection.Open();
            List<CartEntity> bookEntities = new List<CartEntity>();
            SqlCommand cmd = new SqlCommand("GetBooks", connection);
            cmd.Parameters.AddWithValue("@USERID", USERID);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader sdr = cmd.ExecuteReader();

            while (sdr.Read())
            {
                //BookEntity book = new BookEntity();
                CartEntity book=new CartEntity();
                book.BOOKID = Convert.ToInt32(sdr["BOOKID"]);
                book.TITLE = sdr["TITLE"].ToString();
                book.AUTHOR = sdr["AUTHOR"].ToString();
                book.IMAGE = sdr["IMAGE"].ToString();
                book.QUANTITY = Convert.ToInt32(sdr["QUANTITY"]);
                book.FULLNAME = sdr["FULLNAME"].ToString();
               // book.PHONENUMBER = Convert.ToInt32(sdr["PHONENUMBER"]);
                bookEntities.Add(book);

            }
            connection.Close();
            return bookEntities;
        }

        public List<BookEntity> GetCartItems(int USERID)
        {
            SqlConnection connection = (SqlConnection)bookContext.CreateConnection();
            connection.Open();
            List<BookEntity> bookEntities = new List<BookEntity>();
            SqlCommand cmd = new SqlCommand("GetCartItems", connection);
            cmd.Parameters.AddWithValue("@USERID", USERID);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader sdr = cmd.ExecuteReader();

            while (sdr.Read())
            {
                BookEntity book = new BookEntity();
                book.BOOKID = Convert.ToInt32(sdr["BOOKID"]);
                book.TITLE = sdr["TITLE"].ToString();
                book.AUTHOR = sdr["AUTHOR"].ToString();
                book.IMAGE = sdr["IMAGE"].ToString();
                book.QUANTITY = Convert.ToInt32(sdr["QUANTITY"]);

                bookEntities.Add(book);

            }
            connection.Close();
            return bookEntities;
        }

        public object UpdateCart(CartModel model, int USERID)
        {
            SqlConnection connection = (SqlConnection)bookContext.CreateConnection();
            connection.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("UpdateCart", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@USERID", USERID);
                cmd.Parameters.AddWithValue("@BOOKID", model.BOOKID);
                cmd.Parameters.AddWithValue("@Quantity", model.Quantity);
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
            return GetCartItems(USERID);
        }
    }
}
