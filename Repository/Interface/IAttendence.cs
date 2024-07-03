using ModelLayer;
using ModelLayer.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IAttendence
    {
        public Attendence AddAttendance(Attendence model);
        public object Update(int attendance_id);
        public object Delete(int attendance_id);
        public object GetAttendance(int user_id);
    }
}
