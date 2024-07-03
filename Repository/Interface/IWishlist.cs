using ModelLayer.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IWishlist
    {
        public OrdersModel AddWishlist(OrdersModel ordersModel);
        public object GetById(int Id);
        public object DeleteById(int Id);
    }
}
