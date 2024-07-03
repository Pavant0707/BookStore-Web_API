using Bussiness.IuserBL;
using Bussiness.USERbl;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelLayer;
using ModelLayer.BookModel;

namespace Bookstore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class attendenceController : ControllerBase
    {
        private readonly IAttendenceBL attendenceBL;

        public attendenceController(IAttendenceBL attendenceBL)
        {
            this.attendenceBL = attendenceBL;
        }
        [HttpPost("AddAttendance")]
        public IActionResult AddAttendance(Attendence model)
        {
            var result = attendenceBL.AddAttendance(model);
            if (result != null)
            {
                return Ok(new { IsSuccess = true, Message = "Successful", Data = result });

            }
            return BadRequest(new { IsSuccess = false, Message = " failled" });

        }
    }
}
