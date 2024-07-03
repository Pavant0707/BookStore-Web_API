using ModelLayer.FeedBackModel;
using ModelLayer.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IOrderRL
    {
        public OrdersModel AddOrder(OrdersModel ordersModel);
        public object DeleteOrder(int ORDERID);
        public object GetOrder(int ORDERID);

    }
}
