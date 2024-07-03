using ModelLayer.BookModel;
using ModelLayer.CartModel;
using Repository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface ICartRL
    {
        public List<BookEntity> AddCart(CartModel model,int USERID);
        public List<BookEntity> GetCartItems(int USERID);
        public object UpdateCart(CartModel model,int USERID);
        public object deleteCart(int CartId);
        //check how many books is there in a cart for a specific user
        //and print it alongwith user details(name and number + cart info)
        //public List<BookEntity> GetBooks(int USERID);
        public List<CartEntity> GetBooks(int USERID);
    }
}
