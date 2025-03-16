using DO;
using DalApi;
using Tools;
using System.Reflection;

namespace Dal
{
    internal class ProductImplemetation : IProduct
    {
        string project = MethodBase.GetCurrentMethod().DeclaringType.Name;

        public int Create(Product product)
        {
            if (DataSource.Products.FirstOrDefault(c => c._uniqueId == product._uniqueId) != null)
                throw new DalIdAlreadyExistsException("This product ID already exists in the list.");
            DataSource.Products.Add(product);
            LogManager.WriteLog(project, MethodBase.GetCurrentMethod().Name, "Product added successfully");
            return product._uniqueId;
        }
        public void Delete(int id)
        {
            Product product = DataSource.Products.FirstOrDefault(c => c._uniqueId == id);
            if (product == null)
                throw new DalIdNotExistsException("This ID does not exist.");
            DataSource.Products.Remove(product);
            LogManager.WriteLog(project, MethodBase.GetCurrentMethod().Name, "The product was successfully deleted.");
        }

        public Product? Read(int id)
        {
            LogManager.WriteLog(project, MethodBase.GetCurrentMethod().Name, "product read successfully");
            return DataSource.Products.FirstOrDefault(c => c._uniqueId == id);
        }

        public Product? Read(Func<Product, bool> filter)
        {
            LogManager.WriteLog(project, MethodBase.GetCurrentMethod().Name, "product read with filter successfully");
            return DataSource.Products.FirstOrDefault(c => filter(c));
        }


        public List<Product?> ReadAll(Func<Product, bool>? filter = null)
        {
            LogManager.WriteLog(project, MethodBase.GetCurrentMethod().Name, "products read successfully");
            if (filter == null)
                return DataSource.Products.ToList();
            return DataSource.Products.Where(c => filter(c)).ToList();
        }
    

    
    public void Update(Product product)
    {
        Product existingProduct = DataSource.Products.FirstOrDefault(c => c._uniqueId == product._uniqueId); // מחפש את הלקוח הקיים
        if (existingProduct == null)
            throw new DalIdNotExistsException("This product ID does not exist.");
        Product _updateProduct = existingProduct with
        {
            _productName = product._productName,
            _category = product._category,
            _price = product._price,
            _quantityInStock = product._quantityInStock


        };
        int index = DataSource.Products.IndexOf(existingProduct);
        if (index >= 0)
            DataSource.Products[index] = _updateProduct;
        LogManager.WriteLog(project, MethodBase.GetCurrentMethod().Name, "Product updated successfully");


    }
}
}
