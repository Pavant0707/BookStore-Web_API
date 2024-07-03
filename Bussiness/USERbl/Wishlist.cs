using Bussiness.IuserBL;
using ModelLayer.Orders;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.USERbl
{
    public class WishlistBL: IWishlistBL
    {
        private readonly IWishlist wishlist;

        public WishlistBL(IWishlist wishlist)
        {
            this.wishlist = wishlist;
        }

        public OrdersModel AddWishlist(OrdersModel ordersModel)
        {
            return wishlist.AddWishlist(ordersModel);
        }

        public object DeleteById(int Id)
        {
            return wishlist.DeleteById(Id);
        }

        public object GetById(int Id)
        {
            return wishlist.GetById(Id);
        }
    }
}
