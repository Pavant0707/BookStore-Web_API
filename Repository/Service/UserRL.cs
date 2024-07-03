using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ModelLayer.ForgetPassword;
using ModelLayer.LoginModel;
using ModelLayer.Token;
using ModelLayer.UserModel;
using Repository.Context;
using Repository.Entity;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Service
{
    public class UserRL : IuserRL
    {
        private readonly IConfiguration iconfiguration;
        private readonly BookContext bookContext;

        public UserRL(IConfiguration iconfiguration, BookContext bookContext)
        {
            this.iconfiguration = iconfiguration;
            this.bookContext = bookContext;
        }

        public object GetAllUser()
        {
            SqlConnection connection = (SqlConnection)bookContext.CreateConnection();
            connection.Open();

            List<UserEntity> users = new List<UserEntity>();
            SqlCommand cmd = new SqlCommand("GET_ALL_USER", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader sdr = cmd.ExecuteReader();

            while (sdr.Read())
            {
                UserEntity user = new UserEntity();
                user.USERID = Convert.ToInt32(sdr["USERID"]);
                user.FULLNAME = sdr["FULLNAME"].ToString();
                user.EMAILID = sdr["EMAILID"].ToString();
                user.PASSWORD = sdr["PASSWORD"].ToString();
                user.PHONENUMBER = sdr["PHONENUMBER"].ToString();
                users.Add(user);

            }
            connection.Close();
            return users;

        }
        private string GenerateToken(int USERID, string EMAILID)
        {
            // Create a symmetric security key using the JWT key specified in the configuration
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(iconfiguration["Jwt:Key"]));
            // Create signing credentials using the security key and HMAC-SHA256 algorithm
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            // Define claims to be included in the JWT
            var claims = new[]
            {
          new Claim("EMAILID",EMAILID),
          new Claim("USERID", USERID.ToString())
      };
            // Create a JWT with specified issuer, audience, claims, expiration time, and signing credentials
            var token = new JwtSecurityToken(iconfiguration["Jwt:Issuer"], iconfiguration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMonths(2),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public TokenModel Login(LoginModel user)
        {
            UserEntity entity = new UserEntity();
            SqlConnection connection = (SqlConnection)bookContext.CreateConnection();
            
            try
            {
                SqlCommand cmd = new SqlCommand("LOGIN_USERS", connection);
                cmd.CommandType = CommandType.StoredProcedure;             
                cmd.Parameters.AddWithValue("@EMAILID", user.EMAILID);
                cmd.Parameters.AddWithValue("@PASSWORD", user.PASSWORD);
                connection.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    
                    entity.EMAILID = sdr["EMAILID"].ToString();
                    entity.PASSWORD = sdr["PASSWORD"].ToString();
                    entity.USERID = Convert.ToInt32(sdr["USERID"]);
                    entity.FULLNAME = sdr["FULLNAME"].ToString();
                    
                }
                if(entity.EMAILID==user.EMAILID && entity.PASSWORD == user.PASSWORD)
                {
                    TokenModel model = new TokenModel();
                    var token =GenerateToken(entity.USERID, entity.EMAILID);
                    model.USERID=entity.USERID;
                    model.EMAILID = entity.EMAILID;
                    model.PASSWORD = entity.PASSWORD;
                    model.FULLNAME = entity.FULLNAME;
                    model.PHONENUMBER = entity.PHONENUMBER; 
                    model.TOKEN = token;
                    return model;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return null;
        }

        public UserModel USerRegisteration(UserModel user)
        {
            SqlConnection connection = (SqlConnection)bookContext.CreateConnection();
            connection.Open();

            try
            {
                SqlCommand cmd = new SqlCommand("REGISTER_USER", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FULLNAME", user.FULLNAME);
                cmd.Parameters.AddWithValue("@EMAILID", user.EMAILID);
                cmd.Parameters.AddWithValue("@PASSWORD", user.PASSWORD);
                cmd.Parameters.AddWithValue("@PHONENUMBER", user.PHONENUMBER);
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
            return user;
        }

        public object UpdateUser(int USERID, UserModel user)
        {
            SqlConnection connection = (SqlConnection)bookContext.CreateConnection();
            connection.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("UPDATEUSERS", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@USERID",USERID);
                cmd.Parameters.AddWithValue("@FULLNAME", user.FULLNAME);
                cmd.Parameters.AddWithValue("@EMAILID", user.EMAILID);
                cmd.Parameters.AddWithValue("@PASSWORD", user.PASSWORD);
                cmd.Parameters.AddWithValue("@PHONENUMBER", user.PHONENUMBER);
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

        public object DeleteUser(int USERID)
        {
            SqlConnection connection = (SqlConnection)bookContext.CreateConnection();
            connection.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("DELETEUSER", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@USERID",USERID);
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

        public ForgotPassword ForgotPassword(string EMAILID)
        {
            SqlConnection connection = (SqlConnection)bookContext.CreateConnection();
            connection.Open();
            {
                try
                {
                    UserEntity user = new UserEntity();

                    SqlCommand cmd = new SqlCommand("FORGOT_PASSWORD", (SqlConnection)connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@EMAILID", EMAILID);
                    
                    SqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        user.USERID = Convert.ToInt32(dataReader["USERID"]);
                        user.FULLNAME = dataReader["FULLNAME"].ToString();
                        user.EMAILID = dataReader["EMAILID"].ToString();
                        user.PASSWORD = dataReader["PASSWORD"].ToString();
                       user.PHONENUMBER = dataReader["PHONENUMBER"].ToString();

                    }
                    if (EMAILID == user.EMAILID)
                    {
                        ForgotPassword model = new ForgotPassword();

                        model.USERID = user.USERID;
                        model.EMAILID = user.EMAILID;
                        model.TOKEN = GenerateToken(user.USERID, user.EMAILID);
                        return model;
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
                return null;

            }
        }

        public bool ResetPassword(string EMAILID, string PASSWORD)
        {
            SqlConnection connection = (SqlConnection)bookContext.CreateConnection();
            connection.Open();
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("RESETPASSWORD", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EMAILID", EMAILID);
                    cmd.Parameters.AddWithValue("@PASSWORD", PASSWORD);
                    cmd.ExecuteNonQuery();
                    
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
                return false;
            }
        }
    }
}
    

