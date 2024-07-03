using Bussiness.IuserBL;
using Bussiness.USERbl;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.BookModel;
using ModelLayer.CartModel;

namespace Bookstore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartBL cartBL;

        public CartController(ICartBL cartBL)
        {
            this.cartBL = cartBL;
        }
        [HttpPost("AddCart")]
        public IActionResult AddCart(CartModel model, int USERID)
        {
            var result = cartBL.AddCart(model, USERID);
            if (result != null)
            {
                return Ok(new { IsSuccess = true, Message = "Successful", Data = result });

            }
            return BadRequest(new { IsSuccess = false, Message = " failled" });

        }
        [HttpGet("GetCartItems")]
        public IActionResult GetCartItems(int USERID)
        {
            var result = cartBL.GetCartItems(USERID);
            if (result != null)
            {
                return Ok(new { IsSuccess = true, Message = "Successful", Data = result });

            }
            return BadRequest(new { IsSuccess = false, Message = " failled" });

        }
        [HttpGet("GetBooks")]
        public IActionResult GetBooks(int USERID)
        {
            var result = cartBL.GetBooks(USERID);
            if (result != null)
            {
                return Ok(new { IsSuccess = true, Message = "Successful", Data = result });

            }
            return BadRequest(new { IsSuccess = false, Message = " failled" });
        }
            [HttpPost("UpdateCart")]
        public IActionResult UpdateCart(CartModel model, int USERID)
        {
            var result = cartBL.UpdateCart(model,USERID);
            if (result != null)
            {
                return Ok(new { IsSuccess = true, Message = "Successful", Data = result });

            }
            return BadRequest(new { IsSuccess = false, Message = " failled" });

        }
        [HttpDelete("Delete")]
        public IActionResult deleteCart(int CartId)
        {
            var result = cartBL.deleteCart(CartId);
            if (result != null)
            {
                return Ok(new { IsSuccess = true, Message = "Successful", Data = result });

            }
            return BadRequest(new { IsSuccess = false, Message = " failled" });

        }
    }
}
