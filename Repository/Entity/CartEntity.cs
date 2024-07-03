using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entity
{
    public class CartEntity
    {
        public int BOOKID {  get; set; }
        public int USERID { get; set; }
        public int CartID { get; set; }
        public string FULLNAME { get; set; }
        public string PHONENUMBER { get; set; }
        public string TITLE { get; set; }
        public string AUTHOR { get; set; }
        public Decimal TotalPrice { get; set; }
        public Decimal TOTALORIGINALPRICE { get; set; }
        public string IMAGE { get; set; }
        public int QUANTITY { get; set; }
    }
}
