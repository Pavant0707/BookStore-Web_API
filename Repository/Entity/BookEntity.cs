using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entity
{
    public class BookEntity
    {
        public int BOOKID { get; set; }
        public string TITLE { get; set; }
        public string AUTHOR { get; set; }
        public float RATING { get; set; }
        public int RATINGCOUNT { get; set; }
        public Decimal PRICE { get; set; }
        public Decimal ORIGINALPRICE { get; set; }
        public Decimal DISCOUNTPERCENTAGE { get; set; }
        public String DESCRIPTION { get; set; }
        public string IMAGE { get; set; }
        public int QUANTITY { get; set; }
        public string FULLNAME { get; set; }
        
    }
}
