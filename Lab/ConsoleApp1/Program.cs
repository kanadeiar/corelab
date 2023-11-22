using System;
using System.Text;

namespace ConsoleApp1;

static class Program
{
    public static void Main(string[] args)
    {




        Console.WriteLine("Нажмиту любую кнопку ...");
        Console.ReadKey();
    }

    public static string renderPageWithSetupsAndTeardowns(string pageData, bool isSuite)
    {
        if (IsTestPage(pageData))
        {
            IncludeSetupAndTeardownPages(pageData, isSuite);
        }
        return pageData.getHtml();
    }

    private static bool IsTestPage(string pageData)
    {
        var isTestPage = pageData.hasAttribute("Test");
        return isTestPage;
    }

    private static void IncludeSetupAndTeardownPages(string pageData, bool isSuite)
    {
        WikiPage testPage = pageData.getWikiPage();
        StringBuffer newPageContent = new StringBuffer();
        IncludeSetupPages(testPage, isSuite, newPageContent);
        newPageContent.append(pageData.getContext());
        IncludeTeardownPages(testPage, isSuite, newPageContent);
        pageData.setContext(newPageContent.toString());
    }

    private static void IncludeSetupPages(WikiPage page, bool isSuite, StringBuffer newPageContent)
    {
        if (isSuite)
        {
            WikiPage suiteSetup = PageChawlerImpl.getInheritedPage(page);
            if (suiteSetup != null)
            {
                var pagePath = suiteSetup.getPageCrawler().getFullPath(suiteSetup);
                var pagePathName = PathParser.render(pagePath);
                newPageContent.append("!include -setup ").append(pagePathName).append("\n");
            }
        }
        var setup = PageChawlerImpl.getInheritedPage("SetUp", page);
        if (setup != null)
        {
            var pagePath = suiteSetup.getPageCrawler().getFullPath(suiteSetup);
            var pagePathName = PathParser.render(pagePath);
            newPageContent.append("!include -setup ").append(pagePathName).append("\n");
        }
    }

    private static void IncludeTeardownPages(WikiPage page, bool isSuite, StringBuffer newPageContent)
    {
        WikiPage teardown = PageChawlerImpl.getInheritedPage("TearDown", testPage);
        if (teardown != null)
        {
            var pagePath = suiteSetup.getPageCrawler().getFullPath(suiteSetup);
            var pagePathName = PathParser.render(pagePath);
            buffer.append("\n").append("!include -teardown ").append(pagePathName).append("\n");
        }

        if (isSuite)
        {
            WikiPage suiteSetup = PageChawlerImpl.getInheritedPage(testPage);
            if (suiteSetup != null)
            {
                var pagePath = suiteSetup.getPageCrawler().getFullPath(suiteSetup);
                var pagePathName = PathParser.render(pagePath);
                buffer.append("\n").append("!include -teardown ").append(pagePathName).append("\n");
            }
        }
    }
}

