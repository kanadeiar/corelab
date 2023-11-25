namespace ConsoleApp1.CleanCode;

public class WikiPage : IWikiPage
{
    public IPageCrawler GetPageCrawler()
    {
        return new PageCrawlerImpl();
    }
}

public interface IWikiPage
{
    IPageCrawler GetPageCrawler();
}