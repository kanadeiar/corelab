namespace Platform.Services;

public class HtmlResponseFormatter : IResponseFormatter
{
    public async Task Format(HttpContext context, string content)
    {
        context.Response.ContentType = "text/html";
        await context.Response.WriteAsync($@"
<!DOCTYPE html>
<thml lang=""ru-ru""
<head>
<title>Response</title>
</head>
<body>
<h2>Formatter Response</h2>
<span>{content}</span>
</body>
</html>");
    }
    public bool RichOutput => true;
}
