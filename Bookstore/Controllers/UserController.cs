using Bussiness.IuserBL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.LoginModel;
using ModelLayer.UserModel;

namespace Bookstore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserBL userBL;
        public UserController(IUserBL userBL)
        {
            this.userBL = userBL;
        }
        [HttpPost("Create")]
        public IActionResult Register(UserModel user)
        {
            var result = userBL.RegisterUser(user);
            if (result != null)
            {
                return Ok(new { IsSuccess = true, Message = "Registration Successful", Data = result });

            }
            return BadRequest(new { IsSuccess = false, Message = "Registration failled" });

        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = userBL.GetAllUser();
            if (result != null)
            {
                return Ok(new { IsSuccess = true, Message = " Successful", Data = result });

            }
            return BadRequest(new { IsSuccess = false, Message = "failled" });

        }
        [HttpPost("login")]
        public IActionResult LogIn(LoginModel user)
        {
            var result = userBL.Login(user);
            if (result != null)
            {
                return Ok(new { IsSuccess = true, Message = "Successful", Data = result });

            }
            return BadRequest(new { IsSuccess = false, Message = "failled" });

        }
        [HttpPost("update")]
        public IActionResult update(int USERID,UserModel user)
        {
            var result = userBL.UpdateUser(USERID,user);
            if (result != null)
            {
                return Ok(new { IsSuccess = true, Message = " Successful", Data = result });

            }
            return BadRequest(new { IsSuccess = false, Message = "failled" });

        }
        [HttpDelete("delete")]
        public IActionResult delete(int USERID)
        {
            var result = userBL.DeleteUser(USERID);
            if (result != null)
            {
                return Ok(new { IsSuccess = true, Message = "Successful", Data = result });

            }
            return BadRequest(new { IsSuccess = false, Message = " failled" });

        }
        [HttpPost("Forgot_password")]
        public IActionResult ForgotPassword(string EMAILID)
        {
            var result = userBL.ForgotPassword(EMAILID);
            if (result != null)
            {
                return Ok(new { IsSuccess = true, Message = "Successful", Data = result });

            }
            return BadRequest(new { IsSuccess = false, Message = "failled" });

        }
        [HttpPost("ResetPassword")]
        public IActionResult ForgotPassword(string EMAILID,string PASSWORD)
        {
            var result = userBL.ResetPassword(EMAILID,PASSWORD);
            if (result != null)
            {
                return Ok(new { IsSuccess = true, Message = "Successful", Data = result });

            }
            return BadRequest(new { IsSuccess = false, Message = " failled" });

        }
    }
}
