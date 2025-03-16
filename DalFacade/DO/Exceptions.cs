
namespace DO;

[Serializable]
public class DalIdNotExistsException : Exception
{
    public DalIdNotExistsException(string message) : base(message)
    {

    }
}

[Serializable]
public class DalIdAlreadyExistsException : Exception
{
    public DalIdAlreadyExistsException(string message) : base(message)
    {

    }

}
