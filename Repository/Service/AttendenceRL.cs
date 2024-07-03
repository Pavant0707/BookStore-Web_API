using Microsoft.Extensions.Configuration;
using ModelLayer;
using Repository.Context;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Repository.Service
{
    public class AttendenceRL : IAttendence
    {
        private readonly BookContext bookContext;

        public AttendenceRL(BookContext bookContext)
        {
            this.bookContext = bookContext;
        }

        public Attendence AddAttendance(Attendence model)
        {
            SqlConnection connection = (SqlConnection)bookContext.CreateConnection();
            connection.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("InsertAttendance", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@user_id", model.user_id);
                cmd.Parameters.AddWithValue("@event_id", model.event_id);
                cmd.Parameters.AddWithValue("@attendance_date", model.attendance_date);
                cmd.Parameters.AddWithValue("@status", model.status);
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

        public object Delete(int attendance_id)
        {
            SqlConnection connection = (SqlConnection)bookContext.CreateConnection();
            connection.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("DeleteAttendance", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@attendance_id",attendance_id);
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

        public object GetAttendance(int user_id)
        {
            throw new NotImplementedException();
        }

        public object Update(int attendance_id)
        {
            throw new NotImplementedException();
        }
    }
}
