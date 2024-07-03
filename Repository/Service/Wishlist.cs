using ModelLayer.Orders;
using Repository.Context;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Repository.Entity;

namespace Repository.Service
{
    public class Wishlist: IWishlist
    {
        private readonly BookContext bookContext;

        public Wishlist(BookContext bookContext)
        {
            this.bookContext = bookContext;
        }

        public OrdersModel AddWishlist(OrdersModel model)
        {
            SqlConnection connection = (SqlConnection)bookContext.CreateConnection();
            connection.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@USERID", model.USERID);
                cmd.Parameters.AddWithValue("@BOOKID", model.BOOKID);
                cmd.Parameters.AddWithValue("@TITLE", model.TITLE);
                cmd.Parameters.AddWithValue("@AUTHOR", model.AUTHOR);
                cmd.Parameters.AddWithValue("@IMAGE", model.IMAGE);
                cmd.Parameters.AddWithValue("@QUANTITY", model.QUANTITY);
                cmd.Parameters.AddWithValue("@TotalPrice", model.TotalPrice);
                cmd.Parameters.AddWithValue("@TotalOriginalPrice", model.TotalOriginalPrice);
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

        public object DeleteById(int Id)
        {
            SqlConnection connection = (SqlConnection)bookContext.CreateConnection();
            connection.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("DELETEUSER", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id",Id);
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

        public object GetById(int Id)
        {
            SqlConnection connection = (SqlConnection)bookContext.CreateConnection();
            connection.Open();
            List<BookEntity> bookEntities = new List<BookEntity>();
            SqlCommand cmd = new SqlCommand("", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", Id);
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
    }
}
