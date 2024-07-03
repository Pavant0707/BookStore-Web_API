using Bussiness.IuserBL;
using ModelLayer.Orders;
using Repository.Interface;
using Repository.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.USERbl
{
    public class OrderBL : IOrderBL
    {
        private readonly IOrderRL orderRL;

        public OrderBL(IOrderRL orderRL)
        {
            this.orderRL = orderRL;
        }

        public OrdersModel AddOrder(OrdersModel ordersModel)
        {
            return orderRL.AddOrder(ordersModel);
        }

        public object DeleteOrder(int ORDERID)
        {
            return orderRL.DeleteOrder(ORDERID);
        }

        public object GetOrder(int ORDERID)
        {
            return orderRL.GetOrder(ORDERID);
        }
    }
}
