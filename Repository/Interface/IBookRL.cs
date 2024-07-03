using ModelLayer.BookModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IBookRL
    {
        public BookModel AddBook(BookModel model);
        public object GetBook();
        public object UpdateBook(int BOOKID,BookModel model);
        public object DeleteBook(int BOOKID);
        public object GetBookById(int BOOKID);
        //fetch book using book name and author name
        public object GetBookByName(string TITLE,string AUTHOR);
        
    }
}
