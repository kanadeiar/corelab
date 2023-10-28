namespace NpgsqlDal.Core.Exception;

public class DalException : System.Exception
{
    public string Message { get; set; }
    public DalException(string message, System.Exception? inner = null) 
        : base(message, inner)
    {
        Message = message;
    }
}