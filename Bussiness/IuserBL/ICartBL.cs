using ModelLayer.CartModel;
using Repository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.IuserBL
{
    public interface ICartBL
    {
        public List<BookEntity> AddCart(CartModel model, int USERID);
        public List<BookEntity> GetCartItems(int USERID);
        public object UpdateCart(CartModel model, int USERID);
        //public List<BookEntity> GetBooks(int USERID);
        public List<CartEntity> GetBooks(int USERID);
        public object deleteCart(int CartId);
    }
}
