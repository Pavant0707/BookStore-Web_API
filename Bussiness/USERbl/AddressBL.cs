using Bussiness.IuserBL;
using ModelLayer.AddressModel;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.USERbl
{
    public class AddressBL:IAddressBL
    {
        private readonly IAddressRL addressRL;

        public AddressBL(IAddressRL addressRL)
        {
            this.addressRL = addressRL;
        }

        public object AddAddress(AddressModel address)
        {
           return addressRL.AddAddress(address);
        }

        public object GetAddress(int Id)
        {
            return addressRL.GetAddress(Id);
        }

        public object RemoveAddress(int Id)
        {
            return addressRL.RemoveAddress(Id);
        }

        public object UpdateAddress(AddressModel address)
        {
            return addressRL.UpdateAddress(address);
        }
    }
}
