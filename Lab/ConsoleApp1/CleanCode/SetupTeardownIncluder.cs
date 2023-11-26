using System.Text;

namespace ConsoleApp1.CleanCode;

public class SetupTeardownIncluder
{
    private readonly IPageData _pageData;
    private bool _isSuite;
    private readonly IWikiPage _testPage;
    private readonly StringBuilder _newPageContent;
    private IPageCrawler _pageCrawler;

    public static string Render(IPageData pageData)
    {
        return Render(pageData, false);
    }

    public static string Render(IPageData pageData, bool isSuite)
    {
        return new SetupTeardownIncluder(pageData).renderPageWithSetupAndTeardown(isSuite);
    }

    private SetupTeardownIncluder(IPageData pageData)
    {
        _pageData = pageData;
        _testPage = _pageData.GetWikiPage();
        _newPageContent = new StringBuilder();
        _pageCrawler = _testPage.GetPageCrawler();
    }

    private string renderPageWithSetupAndTeardown(bool isSuite)
    {
        _isSuite = isSuite;
        if (isTestPage())
        {
            includeSetupAndTeardownPages();
        }
        return _pageData.GetHtml();
    }

    private bool isTestPage()
    {
        return _pageData.HasAttribute("test");
    }

    private void includeSetupAndTeardownPages()
    {
        includeSetupPages();
        includePageContent();
        includeTeardownPages();
        updatePageContent();
    }
    
    private void includeSetupPages()
    {
        if (_isSuite)
        {
            includeSuiteSetupPage();
        }
        includeSetupPage();
    }

    private void includeSuiteSetupPage()
    {
        include(SuiteResponse.SUITE_SETUP_NAME, "-setup");
    }

    private void includeSetupPage()
    {
        include("SetUp", "-setup");
    }
    
    private void includePageContent()
    {
        _newPageContent.Append(_pageData.GetContent());
    }

    private void includeTeardownPages()
    {
        _newPageContent.Append("\n");
        includeTeardownPage();
        if (_isSuite)
        {
            includeSuiteTeardownPage();
        }
    }

    private void includeTeardownPage()
    {
        include("TearDown", "-teardown");
    }

    private void includeSuiteTeardownPage()
    {
        include(SuiteResponse.SUITE_TEARDOWN_NAME, "-teardown");
    }

    private void updatePageContent()
    {
        _pageData.SetContent(_newPageContent.ToString());
    }

    private void include(string pageName, string arg)
    {
        var inheritedPage = findInheritedPage(pageName);
        if (inheritedPage != null)
        {
            var pagePathName = getPathNameForPage(inheritedPage);
            buildIncludeDirective(pagePathName, arg, _newPageContent);
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

    private void buildIncludeDirective(string setupPathName, string arg, StringBuilder newPageContent)
    {
        newPageContent.Append("!include ").Append(arg).Append(" .").Append(setupPathName).Append("\n");
    }
}