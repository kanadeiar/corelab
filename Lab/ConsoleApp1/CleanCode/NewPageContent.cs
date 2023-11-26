using System.Text;

namespace ConsoleApp1.CleanCode;

public class NewPageContent
{
    private readonly IWikiPage _testPage;
    private readonly StringBuilder _newPageContent;
    private IPageCrawler _pageCrawler;

    public NewPageContent(IWikiPage testPage)
    {
        _testPage = testPage;
        _pageCrawler = _testPage.GetPageCrawler();
        _newPageContent = new StringBuilder();
    }

    public void Append(string content)
    {
        _newPageContent.Append(content);
    }

    public string GetContent()
    {
        return _newPageContent.ToString();
    }

    public void Include(string pageName, string arg)
    {
        var inheritedPage = findInheritedPage(pageName);
        if (inheritedPage != null)
        {
            var pagePathName = getPathNameForPage(inheritedPage);
            buildIncludeDirective(pagePathName, arg);
        }
    }

    private IWikiPage? findInheritedPage(string pageName)
    {
        return PageCrawlerImpl.GetInheritedPage(pageName, _testPage);
    }

    private string getPathNameForPage(IWikiPage inheritedPage)
    {
        var setupPath = _pageCrawler.GetFullPath(inheritedPage);
        var setupPathName = PathParser.Render(setupPath);
        return setupPathName;
    }

    private void buildIncludeDirective(string setupPathName, string arg)
    {
        _newPageContent.Append("!include ").Append(arg).Append(" .").Append(setupPathName).Append("\n");
    }
}