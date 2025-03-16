using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    public record Product(int _uniqueId, string? _productName, Jewelry _category, double _price, int _quantityInStock)
    {
        public Product() : this(0, null, Jewelry.Braclate, 0.0, 0)
        {

        }
    }
}
