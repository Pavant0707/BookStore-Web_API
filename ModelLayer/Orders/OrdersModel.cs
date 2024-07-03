using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.Orders
{
    public class OrdersModel
    {
        public int Id { get; set; }
        public int ORDERID{ get; set; }
        public int USERID { get; set; }
        public int BOOKID { get; set; }
        public string TITLE { get; set; }
        public string AUTHOR { get; set; }
        public string IMAGE { get; set; }
        public int QUANTITY { get; set; }
        public Decimal TotalPrice { get; set; }
        public Decimal TotalOriginalPrice { get; set; }
        
    }
}
