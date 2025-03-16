
using DO;

namespace DalApi
{
    public interface ICrud<T>
    {
        public int Create(T customer);
        public T? Read(int id);
        public List<T?> ReadAll(Func<T, bool>? filter = null);
        public void Update(T customer);
        public void Delete(int id);
        public T? Read(Func<T, bool> filter);



    }
}
