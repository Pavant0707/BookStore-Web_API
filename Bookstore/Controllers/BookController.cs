using Bussiness.IuserBL;
using Bussiness.USERbl;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.BookModel;

namespace Bookstore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookBL bookBL;

        public BookController(IBookBL bookBL)
        {
            this.bookBL = bookBL;
        }
        [HttpPost("AddBook")]
        public IActionResult AddBook(BookModel model)
        {
            var result = bookBL.AddBook(model);
            if (result != null)
            {
                return Ok(new { IsSuccess = true, Message = "Successful", Data = result });

            }
            return BadRequest(new { IsSuccess = false, Message = " failled" });

        }
        [HttpGet("GetBook")]
        public IActionResult GetBook()
        {
            var result = bookBL.GetBook();
            if (result != null)
            {
                return Ok(new { IsSuccess = true, Message = "Successful", Data = result });

            }
            return BadRequest(new { IsSuccess = false, Message = " failled" });

        }
        [HttpPost("UpdateBook")]
        public IActionResult UpdateBook(int USERID,BookModel model)
        {
            var result = bookBL.UpdateBook(USERID,model);
            if (result != null)
            {
                return Ok(new { IsSuccess = true, Message = "Successful", Data = result });

            }
            return BadRequest(new { IsSuccess = false, Message = " failled" });

        }
        [HttpDelete("DeleteBook")]
        public IActionResult DeleteBook(int BOOKID)
        {
            var result = bookBL.DeleteBook(BOOKID);
            if (result != null)
            {
                return Ok(new { IsSuccess = true, Message = "Successful", Data = result });

            }
            return BadRequest(new { IsSuccess = false, Message = " failled" });

        }
        [HttpGet("GetBookID")]
        public IActionResult GetBookById(int BOOKID)
        {
            var result = bookBL.GetBookById(BOOKID);
            if (result != null)
            {
                return Ok(new { IsSuccess = true, Message = "Successful", Data = result });

            }
            return BadRequest(new { IsSuccess = false, Message = " failled" });

        }
        [HttpGet("GetBookBYName")]
        public IActionResult GetBookByName(string TITLE,string AUTHOR)
        {
            var result = bookBL.GetBookByName(TITLE,AUTHOR);
            if (result != null)
            {
                return Ok(new { IsSuccess = true, Message = "Successful", Data = result });

            }
            return BadRequest(new { IsSuccess = false, Message = " failled" });

        }
    }
}
