namespace Platform.Services;

public class TypeBroker
{
    private static IResponseFormatter _formatter = new HtmlResponseFormatter();

    public static IResponseFormatter Formatter => _formatter ; 
}
