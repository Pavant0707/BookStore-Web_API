using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.Token
{
    public class TokenModel
    {
        public int USERID {  get; set; }
        public string FULLNAME { get; set; }
        public string EMAILID { get; set; }
        public string PASSWORD { get; set; }
        public string PHONENUMBER { get; set; }
        public string TOKEN { get; set; }
    }
}
