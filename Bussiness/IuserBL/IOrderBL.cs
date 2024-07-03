using ModelLayer.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.IuserBL
{
    public interface IOrderBL
    {
        public OrdersModel AddOrder(OrdersModel ordersModel);
        public object DeleteOrder(int ORDERID);
        public object GetOrder(int ORDERID);
    }
}
