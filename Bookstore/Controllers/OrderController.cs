using Bussiness.IuserBL;
using Bussiness.USERbl;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.FeedBackModel;
using ModelLayer.Orders;

namespace Bookstore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderBL orderBL;

        public OrderController(IOrderBL orderBL)
        {
            this.orderBL = orderBL;
        }
        [HttpPost("Create")]
        public IActionResult AddOrder(OrdersModel ordersModel)
        {
            var result = orderBL.AddOrder(ordersModel);
            if (result != null)
            {
                return Ok(new { IsSuccess = true, Message = "Successful", Data = result });

            }
            return BadRequest(new { IsSuccess = false, Message = "failled" });

        }
        
        
        [HttpDelete("Delete")]
        public IActionResult DeleteOrder(int ORDERID)
        {
            var result = orderBL.DeleteOrder(ORDERID);
            if (result != null)
            {
                return Ok(new { IsSuccess = true, Message = "Successful", Data = result });

            }
            return BadRequest(new { IsSuccess = false, Message = "failled" });

        }
        [HttpGet("GetAll")]
        public IActionResult GetOrder(int ORDERID)
        {
            var result = orderBL.GetOrder(ORDERID);
            if (result != null)
            {
                return Ok(new { IsSuccess = true, Message = "Successful", Data = result });

            }
            return BadRequest(new { IsSuccess = false, Message = "failled" });

        }
    }
}
