using avianoise.DAL;
using avianoise.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avianoise.BL
{
    public class AddressBL : IAddressBL
    {
        private readonly IAddressRepository addressRepository;

        public AddressBL(IAddressRepository addressRepository)
        {
            this.addressRepository = addressRepository;
        }

        public Address Create(Address entry)
        {
            return addressRepository.Create(entry);
        }

        public Address GetBySearchLine(string searchLine)
        {
            return addressRepository.GetBySearchLine(searchLine);
        }
    }
}
