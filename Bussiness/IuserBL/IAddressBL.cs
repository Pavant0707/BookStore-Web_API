using ModelLayer.AddressModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.IuserBL
{
    public interface IAddressBL
    {
        public object AddAddress(AddressModel address);
        public object RemoveAddress(int Id);
        public object GetAddress(int Id);
        public object UpdateAddress(AddressModel address);
    }
}
