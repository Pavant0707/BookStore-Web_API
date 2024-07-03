using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.IuserBL
{
    public interface IAttendenceBL
    {
        public Attendence AddAttendance(Attendence model);
        public object Update(int attendance_id);
        public object Delete(int attendance_id);
        public object GetAttendance(int user_id);
    }
}
