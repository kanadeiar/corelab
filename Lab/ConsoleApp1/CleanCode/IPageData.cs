namespace ConsoleApp1.CleanCode;

public interface IPageData
{
    public IWikiPage GetWikiPage();

    public bool HasAttribute(string attribute);

    public string GetContent();

    public void SetContent(string content);

    public string GetHtml();
}

