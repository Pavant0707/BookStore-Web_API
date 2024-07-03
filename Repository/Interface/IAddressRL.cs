using ModelLayer.AddressModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IAddressRL
    {
        public object AddAddress(AddressModel address);
        public object RemoveAddress(int Id);
        public object GetAddress(int AddressId);
        public object UpdateAddress(AddressModel address);
    }
}  
