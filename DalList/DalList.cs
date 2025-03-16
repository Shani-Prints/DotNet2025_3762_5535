using DalApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    internal sealed class DalList : IDal
    {
        public ICustomer Customer => new CustomerImplemetation();
        public IProduct Product => new ProductImplemetation();
        public ISale Sale => new SaleImplemetation();

        private static readonly DalList instance = new DalList();
        public static DalList Instance
        {
            get { return instance; }

        }
        private DalList() { }
    }
}
