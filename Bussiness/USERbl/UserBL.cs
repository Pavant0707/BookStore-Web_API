using Bussiness.IuserBL;
using ModelLayer.ForgetPassword;
using ModelLayer.LoginModel;
using ModelLayer.Token;
using ModelLayer.UserModel;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.USERbl
{
    public class UserBL: IUserBL
    {
        private readonly IuserRL iuserRL;
        public UserBL(IuserRL iuserRL)
        {
            this.iuserRL = iuserRL;
        }

        public object DeleteUser(int USERID)
        {
            return iuserRL.DeleteUser(USERID);
        }

        public ForgotPassword ForgotPassword(string EMAILID)
        {
           return iuserRL.ForgotPassword(EMAILID);
        }

        public object GetAllUser()
        {
            return iuserRL.GetAllUser();
        }

        public TokenModel Login(LoginModel model)
        {
            return iuserRL.Login(model);
        }

        public UserModel RegisterUser(UserModel model)
        {
            return iuserRL.USerRegisteration(model);
        }

        public bool ResetPassword(string EMAILID, string PASSWORD)
        {
            return iuserRL.ResetPassword(EMAILID, PASSWORD);
        }

        public object UpdateUser(int USERID, UserModel userModel)
        {
            return iuserRL.UpdateUser(USERID,userModel);
        }
    }
}
