using ModelLayer.ForgetPassword;
using ModelLayer.LoginModel;
using ModelLayer.Token;
using ModelLayer.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.IuserBL
{
    public interface IUserBL
    {
        public UserModel RegisterUser(UserModel model);
        public Object GetAllUser();
        public TokenModel Login(LoginModel userModel);
        public Object UpdateUser(int USERID, UserModel userModel);
        public Object DeleteUser(int USERID);
        public ForgotPassword ForgotPassword(string EMAILID);
        public bool ResetPassword(string EMAILID, string PASSWORD);
    }
}
