namespace Platform;

public interface IResponseFormatter
{
    Task Format(HttpContext context, string content);
    public bool RichOutput => false;
}
