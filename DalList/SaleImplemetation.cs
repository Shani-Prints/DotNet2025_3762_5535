using DO;
using DalApi;
using System.Reflection;
using Tools;

namespace Dal
{
    internal class SaleImplemetation : ISale
    {
        string project = MethodBase.GetCurrentMethod().DeclaringType.Name;
        public int Create(Sale sale)
        {
            if (DataSource.Sales.FirstOrDefault(c => c._uniqueId == sale._uniqueId) != null)
                throw new DalIdAlreadyExistsException("This sale ID already exists.");
            DataSource.Sales.Add(sale);
            LogManager.WriteLog(project, MethodBase.GetCurrentMethod().Name, "sale crated successfully");

            return sale._uniqueId;
        }

        public void Delete(int id)
        {
            Sale sale = DataSource.Sales.FirstOrDefault(c => c._uniqueId == id);
            if (sale == null)
                throw new DalIdNotExistsException("This ID does not exist.");
            DataSource.Sales.Remove(sale);
            LogManager.WriteLog(project, MethodBase.GetCurrentMethod().Name, "sale deleted successfully");

        }

        public Sale? Read(int id)
        {
            LogManager.WriteLog(project, MethodBase.GetCurrentMethod().Name, "sale read successfully");
            return DataSource.Sales.FirstOrDefault(c => c._uniqueId == id);
        }

        public Sale? Read(Func<Sale, bool> filter)
        {
            LogManager.WriteLog(project, MethodBase.GetCurrentMethod().Name, "Sale read with filter successfully");
            return DataSource.Sales.FirstOrDefault(c => filter(c));
        }

        public List<Sale?> ReadAll(Func<Sale, bool>? filter = null)
        {
            LogManager.WriteLog(project, MethodBase.GetCurrentMethod().Name, "sales read successfully");
            if (filter == null)
                return DataSource.Sales.ToList();
            return DataSource.Sales.Where(c => filter(c)).ToList();
        }

        public void Update(Sale sale)
        {
            Sale exitSale = DataSource.Sales.FirstOrDefault(c => c._uniqueId == sale._uniqueId);
            if (exitSale == null)
                throw new DalIdNotExistsException("This sale ID does not exist.");
            Sale updateSale = exitSale with
            {
                _productId = sale._productId,
                _requiredQuantity = sale._requiredQuantity,
                _totalPrice = sale._totalPrice,
                _isClub = exitSale._isClub,
                _startSale = exitSale._startSale,
                _endSale = exitSale._endSale
            };
            int index = DataSource.Sales.IndexOf(exitSale);
            if (index >= 0)
                DataSource.Sales[index] = updateSale;
            LogManager.WriteLog(project, MethodBase.GetCurrentMethod().Name, "sale update successfully");


        }
    }
}
