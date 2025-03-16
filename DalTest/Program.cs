using DalApi;
using DalTest;
using DO;
using System.Collections.Generic;
using System.Diagnostics;
using Tools;

 public class Program
{
    private static IDal s_dal = Factory.Get;

    public static void printMainMenu()
    {
        Console.WriteLine("for customer press 1");
        Console.WriteLine("for product press 2");
        Console.WriteLine("for sale press 3");
        Console.WriteLine("To clean log folders press 4");
        Console.WriteLine("for exit press 0");

    }
    public static int printSubMenu(String enitity)
    {
        Console.WriteLine(enitity);
        Console.WriteLine("for create press 1");
        Console.WriteLine("for Read press 2");
        Console.WriteLine("for ReadAll press 3");
        Console.WriteLine("for Update press 4");
        Console.WriteLine("for Delete press 5");
        Console.WriteLine("for exit press 0");
        int choice2;
        return !int.TryParse(Console.ReadLine(), out choice2) ? -1 : choice2;

    }

    public static void subCustomer(int choice2)
    {
        while (choice2 != 0)
        {
            switch (choice2)
            {
                case 1:
                    Console.WriteLine("create customer");
                    createCustomer();
                    break;
                case 2:
                    Console.WriteLine("read customer");
                    Console.WriteLine("insert customer id");
                    int id = 0;
                    int.TryParse(Console.ReadLine(), out id);
                    read(s_dal.Customer.Read(id));
                    break;
                case 3:
                    Console.WriteLine("readall customer");
                    readAll(s_dal.Customer.ReadAll());
                    break;
                case 4:
                    Console.WriteLine("update customer");
                    updateCustomer();
                    break;
                case 5:
                    Console.WriteLine("delete customer");
                    delete(s_dal.Customer);
                    break;
                default:
                    Console.WriteLine("ERROR!!,The choise2 is worng");
                    break;
            }
            choice2 = printSubMenu("customer");
        }
    }

    public static void createCustomer()
    {
        Customer Cust = createAndUpdateCustomer();
        try
        {
            Console.WriteLine(s_dal.Customer.Create(Cust));
            Console.WriteLine("sucseed!!!");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            createCustomer();
        }
    }
    public static Customer createAndUpdateCustomer()
    {
        Console.WriteLine("insert ID");
        int Id = int.Parse(Console.ReadLine());
        Console.WriteLine("insert CustName");
        string CustName = Console.ReadLine();
        Console.WriteLine("insert Address");
        string Address = Console.ReadLine();
        Console.WriteLine("insert Phone");
        string Phone = Console.ReadLine();

        Customer Cust = new Customer(Id, CustName, Address, Phone);
        return Cust;
    }

    public static void updateCustomer()
    {
        Customer Cust = createAndUpdateCustomer();
        try
        {
            s_dal.Customer.Update(Cust);
            Console.WriteLine("sucseed!!!");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            updateCustomer();
        }

    }

    public static void subProduct(int choice2)
    {
        while (choice2 != 0)
        {
            switch (choice2)
            {
                case 1:
                    Console.WriteLine("create product");
                    createProduct();
                    break;
                case 2:
                    Console.WriteLine("read product");
                    Console.WriteLine("insert product id");
                    int id = 0;
                    int.TryParse(Console.ReadLine(), out id);
                    read(s_dal.Product.Read(id));
/*                   read(s_dal.Product.Read(product => product._price > 300));
*/                    break;
                case 3:
                    Console.WriteLine("readAll product");
                    readAll(s_dal.Product.ReadAll());
                   /* readAll(s_dal.Product.ReadAll(product => product._price > 300));
*/
                    break;
                case 4:
                    Console.WriteLine("update product");
                    updateProduct();
                    break;
                case 5:
                    Console.WriteLine("delete product");
                    delete(s_dal.Product);
                    break;
                default:
                    Console.WriteLine("ERROR!!,The choise2 is worng");
                    break;
            }
            choice2 = printSubMenu("product");
        }
    }

    public static void createProduct()
    {
        Product pro = createAndUpdateProduct();
        try
        {
            s_dal.Product.Create(pro);
            Console.WriteLine("sucseed!!!");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            createProduct();
        }

    }

    public static Product createAndUpdateProduct()
    {
        Console.WriteLine("insert ID");
        int Id = int.Parse(Console.ReadLine());
        Console.WriteLine("insert ProductName");
        string ProductName = Console.ReadLine();
        Console.WriteLine("insert Category 0:Necklace, 1:Braclate, 2:Earrings, 3:Ring, 4:Watch");//?
        int Category = int.Parse(Console.ReadLine());
        Console.WriteLine("insert Price");
        int Price = int.Parse(Console.ReadLine());
        Console.WriteLine("insert CountInStock");
        int CountInStock = int.Parse(Console.ReadLine());
        Product pro = new Product(Id, ProductName, (Jewelry)Category, Price, CountInStock);
        return pro;
    }

    public static void updateProduct()
    {
        Product pro = createAndUpdateProduct();
        try
        {
            s_dal.Product.Update(pro);
            Console.WriteLine("sucseed!!!");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            updateProduct();
        }
    }

    public static void subSale(int choice2)
    {
        while (choice2 != 0)
        {
            switch (choice2)
            {
                case 1:
                    Console.WriteLine("create sale");
                    Sale s = createAndUpdateSale();
                    s_dal.Sale.Create(s);
                    break;
                case 2:
                    Console.WriteLine("read sale");
                    Console.WriteLine("insert sale id");
                    int id = 0;
                    int.TryParse(Console.ReadLine(), out id);
                    read(s_dal.Sale.Read(id));
                    break;
                case 3:
                    Console.WriteLine("readAll sale");
                    readAll(s_dal.Sale.ReadAll());
                    break;
                case 4:
                    Console.WriteLine("update sale");
                    Sale s2 = createAndUpdateSale();
                    s_dal.Sale.Update(s2);
                    break;
                case 5:
                    Console.WriteLine("delete sale");
                    delete(s_dal.Sale);
                    break;
                default:
                    Console.WriteLine("ERROR!!,The choise2 is worng");
                    break;
            }
            choice2 = printSubMenu("sale");
        }
    }

    public static Sale createAndUpdateSale()
    {
        Console.WriteLine("insert ID");
        int Id = int.Parse(Console.ReadLine());
        Console.WriteLine("insert ProductId");
        int productId = int.Parse(Console.ReadLine());
        Console.WriteLine("insert requiredQuantity");
        int requiredQuantity = int.Parse(Console.ReadLine());
        Console.WriteLine("insert totalPrice");
        double totalPrice = double.Parse(Console.ReadLine());
        Console.WriteLine("if you have club-insert true/false");
        bool isClub = bool.Parse(Console.ReadLine());
        Console.WriteLine("insert BeginSale");
        DateTime BeginSale = DateTime.Parse(Console.ReadLine());
        Console.WriteLine("insert EndSale");
        DateTime EndSale = DateTime.Parse(Console.ReadLine());
        Sale sale = new Sale(Id, productId, requiredQuantity, totalPrice, isClub, BeginSale, EndSale);

        return sale;
    }


    public static void delete<T>(ICrud<T> icrud)
    {
        Console.WriteLine("insert id to delete");
        int code = int.Parse(Console.ReadLine());
        icrud.Delete(code);
    }

    public static void read<T>(T item)
    {
        Console.WriteLine(item);
    }

    public static void readAll<T>(List<T> list)
    {
        foreach (T item in list)
        {
            Console.WriteLine(item);
        }
    }
    static void Main(string[] args)
    {
        try
        {
            Initialization.Initialize();

            int choice1 = 0, choice2 = 0;
            printMainMenu();
            if (!int.TryParse(Console.ReadLine(), out choice1)) { choice1 = -1; }
            while (choice1 != 0)
            {
                switch (choice1)
                {
                    case 1:
                        choice2 = printSubMenu("customer");
                        subCustomer(choice2);
                        break;
                    case 2:
                        choice2 = printSubMenu("product");
                        subProduct(choice2);
                        break;
                    case 3:
                        choice2 = printSubMenu("sale");
                        subSale(choice2);
                        break;
                    case 4:
                        LogManager.CleanOldDirectories();
                        break;
                    default:
                        Console.WriteLine("ERROR!!,The choise1 is worng");
                        break;
                }
                printMainMenu();
                if (!int.TryParse(Console.ReadLine(), out choice1)) { choice1 = -1; }
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }




}