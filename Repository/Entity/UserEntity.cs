using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entity
{
    public class UserEntity
    {
        public int USERID {  get; set; }
        public string FULLNAME { get; set; }
        public string EMAILID { get; set; }
        public string PASSWORD { get; set; }
        public string PHONENUMBER { get; set; }
    }
}
