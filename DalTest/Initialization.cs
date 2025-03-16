using DO;
using DalApi;
namespace DalTest

{
    public static class Initialization
    {
        private static IDal s_dal;
        private static List<int> productCodes = new List<int>() { };

        private static void CreateProduct()
        {
            try
            {
                s_dal.Product.Create(new Product(1, "צמיד פנדורה", Jewelry.Braclate, 350, 20));
                s_dal.Product.Create(new Product(2, "עגילי פנדורה", Jewelry.Earrings, 120, 50));
                s_dal.Product.Create(new Product(3, "שעון מייקל קורס", Jewelry.Watch, 400, 30));

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        private static void CreateCustomer()
        {
            try
            {
                s_dal.Customer.Create(new Customer(1, "Shani", "Chafetz Chaim 19", "0527621806"));
                s_dal.Customer.Create(new Customer(2, "Tzipi", "Chafetz Chaim 19", "0784512956"));
                s_dal.Customer.Create(new Customer(3, "Tamar", "Chafetz Chaim 19", "02281498"));

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        private static void CreateSale()
        {
            try
            {
                s_dal.Sale.Create(new Sale(1, 1, 5, 800, true, new DateTime(), new DateTime()));
                s_dal.Sale.Create(new Sale(2, 2, 20, 50, false, new DateTime(), new DateTime()));
                s_dal.Sale.Create(new Sale(3, 3, 15, 200, true, new DateTime(), new DateTime()));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public static void Initialize()
        {
            s_dal = Factory.Get;
            CreateProduct();
            CreateCustomer();
            CreateSale();

        }

    }
}
