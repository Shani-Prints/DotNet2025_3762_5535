using DO;
using DalApi;
using Tools;
using System.Reflection;

namespace Dal
{
    internal class CustomerImplemetation : ICustomer
    {
        string project = MethodBase.GetCurrentMethod().DeclaringType.Name;

        public int Id { get; private set; }

        public int Create(Customer customer)
        {
            if (DataSource.Customers.FirstOrDefault(c => c._id == customer._id) != null)
                throw new DalIdAlreadyExistsException("This customer already exists.");
            DataSource.Customers.Add(customer);
            LogManager.WriteLog(project, MethodBase.GetCurrentMethod().Name, "customer added successfully");
            return customer._id;
        }
        public void Delete(int id)
        {
            Customer customer = DataSource.Customers.FirstOrDefault(c => c._id == id);
            if (customer == null)
                throw new DalIdNotExistsException("This ID does not exist.");
            DataSource.Customers.Remove(customer);
            LogManager.WriteLog(project, MethodBase.GetCurrentMethod().Name, "The customer was successfully deleted.");

        }

        public Customer? Read(int id)
        {
            LogManager.WriteLog(project, MethodBase.GetCurrentMethod().Name, "customer read successfully");
            return DataSource.Customers.FirstOrDefault(c => c._id == id);
        }

        public Customer? Read(Func<Customer, bool> filter)
        {
            LogManager.WriteLog(project, MethodBase.GetCurrentMethod().Name, "customer read with filter successfully");
            return DataSource.Customers.FirstOrDefault(c => filter(c));
        }

        public List<Customer?> ReadAll(Func<Customer, bool>? filter = null)
        {
            LogManager.WriteLog(project, MethodBase.GetCurrentMethod().Name, "customer read successfully");
            if (filter == null)
                return DataSource.Customers.ToList();
            return DataSource.Customers.Where(c => filter(c)).ToList();
        }


        public void Update(Customer customer)
        {
            Customer existingCustomer = DataSource.Customers.FirstOrDefault(c => c._id == customer._id); // מחפש את הלקוח הקיים
            if (existingCustomer == null)
                throw new DalIdNotExistsException("This customer ID does not exist.");
            Customer _updateCustomer = existingCustomer with
            {
                _customerName = customer._customerName,
                _address = customer._address,
                _phone = customer._phone
            };
            int index = DataSource.Customers.IndexOf(existingCustomer);
            if (index >= 0)
                DataSource.Customers[index] = _updateCustomer;
            LogManager.WriteLog(project, MethodBase.GetCurrentMethod().Name, "customer updated successfully");

        }
    }
}
