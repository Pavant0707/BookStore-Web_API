using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class Attendence
    {
        public int user_id { get; set; }
        public int event_id { get; set; }
        public DateTime attendance_date { get; set; }
        public string status { get; set; }
    }
}
