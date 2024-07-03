using Bussiness.IuserBL;
using ModelLayer.CartModel;
using Repository.Entity;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.USERbl
{
    public class CartBL : ICartBL
    {
        private readonly ICartRL cartRl;

        public CartBL(ICartRL cartRl)
        {
            this.cartRl = cartRl;
        }

        public List<BookEntity> AddCart(CartModel model, int USERID)
        {
            return cartRl.AddCart(model, USERID);   
        }

        public object deleteCart(int CartId)
        {
            return cartRl.deleteCart(CartId);
        }

        //public List<BookEntity> GetBooks(int USERID)
        public List<CartEntity> GetBooks(int USERID)
        {
            return cartRl.GetBooks(USERID);
        }

        public List<BookEntity> GetCartItems(int USERID)
        {
            return cartRl.GetCartItems(USERID);
        }

        public object UpdateCart(CartModel model, int USERID)
        {
            return cartRl.UpdateCart(model, USERID);
        }
    }
}
