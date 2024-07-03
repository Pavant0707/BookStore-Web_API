using ModelLayer.AddressModel;
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
using System.Net;

namespace Repository.Service
{
    public class AddressRl : IAddressRL
    {
        private readonly BookContext bookContext;

        public AddressRl(BookContext bookContext)
        {
             this.bookContext = bookContext;
        }

        public object AddAddress(AddressModel address)
        {
            SqlConnection connection = (SqlConnection)bookContext.CreateConnection();
            connection.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("AddUserAddress", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@USERID",address.USERID);
                cmd.Parameters.AddWithValue("@FullName", address.FullName);
                cmd.Parameters.AddWithValue("@Mobile",address.Mobile );
                cmd.Parameters.AddWithValue("@Address",address.Address);
                cmd.Parameters.AddWithValue("@City", address.City);
                cmd.Parameters.AddWithValue("@State", address.State);
                cmd.Parameters.AddWithValue("@Type", address.Type);
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
            return address;
        }

        public object GetAddress(int AddressId)
        {
            SqlConnection connection = (SqlConnection)bookContext.CreateConnection();
            connection.Open();

            List<AddressModel> users = new List<AddressModel>();
            SqlCommand cmd = new SqlCommand("GetByAddressId", connection);
            cmd.Parameters.AddWithValue("@AddressId", AddressId);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader sdr = cmd.ExecuteReader();

            while (sdr.Read())
            {
                AddressModel model = new AddressModel();
                model.USERID= Convert.ToInt32(sdr["USERID"]);
                model.FullName = sdr["FullName"].ToString();
                model.Mobile= Convert.ToInt32(sdr["Mobile"]);
                model.Address = sdr["Address"].ToString();
                model.City = sdr["City"].ToString();
                model.State = sdr["State"].ToString();
                model.Type = sdr["Type"].ToString();
                users.Add(model);

            }
            connection.Close();
            return users;
        }

        public object RemoveAddress(int Id)
        {
            SqlConnection connection = (SqlConnection)bookContext.CreateConnection();
            connection.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("DeleteUsingAddressIdUserId", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", Id);
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

        public object UpdateAddress(AddressModel address)
        {
            SqlConnection connection = (SqlConnection)bookContext.CreateConnection();
            connection.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("UpdateByUserAddressId", connection);
                cmd.CommandType = CommandType.StoredProcedure;
               // cmd.Parameters.AddWithValue("@Id", address.Id);
                cmd.Parameters.AddWithValue("@FullName", address.FullName);
                cmd.Parameters.AddWithValue("@Mobile", address.Mobile);
                cmd.Parameters.AddWithValue("@Address", address.Address);
                cmd.Parameters.AddWithValue("@City", address.City);
                cmd.Parameters.AddWithValue("@State", address.State);
                cmd.Parameters.AddWithValue("@Type", address.Type);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                connection.Close();

            }  
            return address;
        }
    }
}
