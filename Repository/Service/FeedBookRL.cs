using ModelLayer.FeedBackModel;
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
using System.Net;
using Repository.Entity;

namespace Repository.Service
{
    public class FeedBookRL: IFeddBackRLcs
    {
        private readonly BookContext bookContext;

        public FeedBookRL(BookContext bookContext)
        {
           this.bookContext = bookContext;
        }

        public FeedBackModelcs AddFeedBack(FeedBackModelcs model)
        {
            SqlConnection connection = (SqlConnection)bookContext.CreateConnection();
            connection.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("AddFeedBack", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BOOKID", model.BOOKID);
                cmd.Parameters.AddWithValue("@USERID", model.USERID);
                cmd.Parameters.AddWithValue("@RATING", model.RATING);
                cmd.Parameters.AddWithValue("@REVIEW", model.REVIEW);
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

        public object DeleteFeedBack(int FEEDBACKID)
        {
            SqlConnection connection = (SqlConnection)bookContext.CreateConnection();
            connection.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("DeleteFeedback", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FEEDBACKID", FEEDBACKID);
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

        public object GetAll()
        {
            SqlConnection connection = (SqlConnection)bookContext.CreateConnection();
            connection.Open();

            List<FeedBackEntity> bookEntities = new List<FeedBackEntity>();
            SqlCommand cmd = new SqlCommand("GetAllFeedbacks", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                FeedBackEntity book = new FeedBackEntity();
                book.FEEDBACKID = Convert.ToInt32(sdr["FEEDBACKID"]);
                book.BOOKID = Convert.ToInt32(sdr["BOOKID"]);
                book.USERID = Convert.ToInt32(sdr["USERID"]);
                book.RATING = Convert.ToInt32(sdr["RATING"]);
                book.FULLNAME = sdr["FULLNAME"].ToString();
                book.REVIEW = sdr["REVIEW"].ToString();
                bookEntities.Add(book);

            }
            connection.Close();
            return bookEntities;

        }

        public object UpdateFeedback(UpdateFeed model)
        {
            SqlConnection connection = (SqlConnection)bookContext.CreateConnection();
            connection.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("UpdateFeedback", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FEEDBACKID", model.FEEDBACKID);
                cmd.Parameters.AddWithValue("@BOOKID", model.BOOKID);
                cmd.Parameters.AddWithValue("@USERID", model.USERID);
                cmd.Parameters.AddWithValue("@FULLNAME",model.FULLNAME);
                cmd.Parameters.AddWithValue("@RATING", model.RATING);
                cmd.Parameters.AddWithValue("@REVIEW", model.REVIEW);
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
