using Bussiness.IuserBL;
using ModelLayer;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.USERbl
{
    public class AttendenceBL : IAttendenceBL
    {
        private readonly IAttendence attendenceRL;

        public AttendenceBL(IAttendence attendenceRL)
        {
            this.attendenceRL = attendenceRL;
        }

        public Attendence AddAttendance(Attendence model)
        {
            return attendenceRL.AddAttendance(model);
        }

        public object Delete(int attendance_id)
        {
            throw new NotImplementedException();
        }

        public object GetAttendance(int user_id)
        {
            throw new NotImplementedException();
        }

        public object Update(int attendance_id)
        {
            throw new NotImplementedException();
        }
    }
}
