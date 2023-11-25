using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.CleanCode
{
    public class SetupTeardownIncluder
    {
        public string TestableHtml(IPageData pageData, bool includeSuiteSetup)
        {
            var wikiPage = pageData.GetWikiPage();
            var buffer = new StringBuilder();

            if (pageData.HasAttribute("test"))
            {
                if (includeSuiteSetup)
                {
                    var suiteSetup = PageCrawlerImpl.GetInheritedPage(SuiteResponse.SUITE_SETUP_NAME, wikiPage);
                    if (suiteSetup != null)
                    {
                        var setupPath = wikiPage.GetPageCrawler().GetFullPath(suiteSetup);
                        var setupPathName = PathParser.Render(setupPath);
                        buffer.Append("!include -setup .").Append(setupPathName).Append("\n");
                    }
                }
                var setup = PageCrawlerImpl.GetInheritedPage("SetUp", wikiPage);
                if (setup != null)
                {
                    var setupPath = wikiPage.GetPageCrawler().GetFullPath(setup);
                    var setupPathName = PathParser.Render(setupPath);
                    buffer.Append("!include -setup .").Append(setupPathName).Append("\n");
                }
            }

            buffer.Append(pageData.GetContent());
            
            if (pageData.HasAttribute("test"))
            {
                buffer.Append("\n");
                var teardown = PageCrawlerImpl.GetInheritedPage("TearDown", wikiPage);
                if (teardown != null)
                {
                    var setupPath = wikiPage.GetPageCrawler().GetFullPath(teardown);
                    var setupPathName = PathParser.Render(setupPath);
                    buffer.Append("!include -teardown .").Append(setupPathName).Append("\n");
                }

                if (includeSuiteSetup)
                {
                    var teardownSetup = PageCrawlerImpl.GetInheritedPage(SuiteResponse.SUITE_TEARDOWN_NAME, wikiPage);
                    if (teardownSetup != null)
                    {
                        var setupPath = wikiPage.GetPageCrawler().GetFullPath(teardownSetup);
                        var setupPathName = PathParser.Render(setupPath);
                        buffer.Append("!include -teardown .").Append(setupPathName).Append("\n");
                    }
                }
            }

            var text = buffer.ToString();
            pageData.SetContent(text);
            return pageData.GetHtml();
        }
    }
}
