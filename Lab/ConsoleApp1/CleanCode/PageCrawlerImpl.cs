namespace ConsoleApp1.CleanCode;

class SuiteResponse
{
    public const string SUITE_SETUP_NAME = "SETUP";
    public const string SUITE_TEARDOWN_NAME = "TEARDOWN";
}

public interface IPageCrawler
{
    IWikiPagePath GetFullPath(IWikiPage page);
}

public class PageCrawlerImpl : IPageCrawler
{
    public static IWikiPage? GetInheritedPage(string name, IWikiPage page)
    {
        return new WikiPage();
    }

    public IWikiPagePath GetFullPath(IWikiPage page)
    {
        return new WikiPagePath();
    }
}