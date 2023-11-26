using System.Text;

namespace ConsoleApp1.CleanCode;

public class SetupTeardownIncluder
{
    private readonly IPageData _pageData;
    private bool _isSuite;
    private NewPageContent _content;

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
        _content = new NewPageContent(_pageData.GetWikiPage());
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
        _content.Include(SuiteResponse.SUITE_SETUP_NAME, "-setup");
    }

    private void includeSetupPage()
    {
        _content.Include("SetUp", "-setup");
    }
    
    private void includePageContent()
    {
        _content.Append(_pageData.GetContent());
    }

    private void includeTeardownPages()
    {
        _content.Append("\n");
        includeTeardownPage();
        if (_isSuite)
        {
            includeSuiteTeardownPage();
        }
    }

    private void includeTeardownPage()
    {
        _content.Include("TearDown", "-teardown");
    }

    private void includeSuiteTeardownPage()
    {
        _content.Include(SuiteResponse.SUITE_TEARDOWN_NAME, "-teardown");
    }

    private void updatePageContent()
    {
        _pageData.SetContent(_content.GetContent());
    }
}