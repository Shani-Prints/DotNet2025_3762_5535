using DO;

namespace Dal
{

    static internal class DataSource
    {
        static internal List<Product>? Products = new List<Product>();
        static internal List<Customer>? Customers = new List<Customer>();
        static internal List<Sale>? Sales = new List<Sale>();

        static internal class Config
        {
            internal const int _saleUniqeId = 1;
            static private int _prevSaleUniqeId = _saleUniqeId;
            public static int _returnSaleUniqeId
            {
                get
                {
                    return ++_prevSaleUniqeId;
                }
            }

        }

    }
}
