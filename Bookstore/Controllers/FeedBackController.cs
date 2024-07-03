using Bussiness.IuserBL;
using Bussiness.USERbl;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.FeedBackModel;
using ModelLayer.UserModel;

namespace Bookstore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedBackController : ControllerBase
    {
        private readonly IFeedBackBL feedBackBL;

        public FeedBackController(IFeedBackBL  feedBackBL)
        {
            this.feedBackBL = feedBackBL;
        }

        [HttpPost("Create")]
        public IActionResult AddFeedBack(FeedBackModelcs model)
        {
            var result = feedBackBL.AddFeedBack(model);
            if (result != null)
            {
                return Ok(new { IsSuccess = true, Message = "Successful", Data = result });

            }
            return BadRequest(new { IsSuccess = false, Message = "failled" });

        }
        [HttpPost("Update")]
        public IActionResult UpdateFeedback(UpdateFeed model)
        {
            var result = feedBackBL.UpdateFeedback(model);
            if (result != null)
            {
                return Ok(new { IsSuccess = true, Message = "Successful", Data = result });

            }
            return BadRequest(new { IsSuccess = false, Message = "failled" });

        }
        [HttpDelete("Delete")]
        public IActionResult DeleteFeedBack(int FEEDBACKID)
        {
            var result = feedBackBL.DeleteFeedBack(FEEDBACKID);
            if (result != null)
            {
                return Ok(new { IsSuccess = true, Message = "Successful", Data = result });

            }
            return BadRequest(new { IsSuccess = false, Message = "failled" });

        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = feedBackBL.GetAll(); 
            if (result != null)
            {
                return Ok(new { IsSuccess = true, Message = "Successful", Data = result });

            }
            return BadRequest(new { IsSuccess = false, Message = "failled" });

        }
    }
}
