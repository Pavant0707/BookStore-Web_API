using Bussiness.IuserBL;
using Bussiness.USERbl;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.AddressModel;
using ModelLayer.UserModel;

namespace Bookstore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
       private readonly IAddressBL addressBL;

        public AddressController(IAddressBL addressBL)
        {
            this.addressBL = addressBL;
        }
        [HttpPost("AddAddress")]
        public IActionResult AddAddress(AddressModel address)
        {
            var result = addressBL.AddAddress(address);
            if (result != null)
            {
                return Ok(new { IsSuccess = true, Message = " Successful", Data = result });

            }
            return BadRequest(new { IsSuccess = false, Message = "failled" });

        }
        [HttpDelete("RemoveAddress")]
        public IActionResult RemoveAddress(int Id)
        {
            var result = addressBL.RemoveAddress(Id);
            if (result != null)
            {
                return Ok(new { IsSuccess = true, Message = " Successful", Data = result });

            }
            return BadRequest(new { IsSuccess = false, Message = "failled" });

        }
        [HttpGet("GetAddress")]
        public IActionResult GetAddress(int Id)
        {
            var result = addressBL.GetAddress(Id);
            if (result != null)
            {
                return Ok(new { IsSuccess = true, Message = " Successful", Data = result });

            }
            return BadRequest(new { IsSuccess = false, Message = "failled" });

        }
        [HttpPost(" UpdateAddress")]
        public IActionResult UpdateAddress(AddressModel address)
        {
            var result = addressBL.UpdateAddress(address);
            if (result != null)
            {
                return Ok(new { IsSuccess = true, Message = " Successful", Data = result });

            }
            return BadRequest(new { IsSuccess = false, Message = "failled" });

        }
    }
}
