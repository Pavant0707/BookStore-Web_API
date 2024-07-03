using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.BookModel
{
    public class BookModel
    {
        public string TITLE { get; set; }
        public string AUTHOR { get; set; }

        public Decimal ORIGINALPRICE {  get; set; }
        public Decimal DISCOUNTPERCENTAGE {  get; set; }
        public String DESCRIPTION { get; set; }
        public string IMAGE { get; set; }
        public int QUANTITY { get; set; }

    }
}
