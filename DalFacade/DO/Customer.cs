using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    public record Customer(int _id, string _customerName, string _address, string _phone)
    {

        public Customer() : this(0, null, null, null)
        {

        }

    }

}
