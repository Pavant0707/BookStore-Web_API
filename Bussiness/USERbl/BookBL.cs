using Bussiness.IuserBL;
using ModelLayer.BookModel;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.USERbl
{
    public class BookBL : IBookBL
    {
        private readonly IBookRL ibookRL;

        public BookBL(IBookRL ibookRL)
        {
            this.ibookRL = ibookRL;
        }

        public BookModel AddBook(BookModel model)
        {
            return ibookRL.AddBook(model);
        }

        public object DeleteBook(int BOOKID)
        {
            return ibookRL.DeleteBook(BOOKID);
        }

        public object GetBook()
        {
            return ibookRL.GetBook();
        }

        public object GetBookById(int BOOKID)
        {
            return ibookRL.GetBookById(BOOKID);
        }

        public object GetBookByName(string TITLE, string AUTHOR)
        {
            return ibookRL.GetBookByName(TITLE,AUTHOR);
        }

        public object UpdateBook(int BOOKID, BookModel model)
        {
            return ibookRL.UpdateBook(BOOKID, model);
        }
    }
}
