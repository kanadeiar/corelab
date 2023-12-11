namespace ConsoleApp1.Tests.UnitTests
{
    public class SymbolicPage
    {
        public const string PROPERTY_NAME = "NAME";
    }

    public interface IWikiPageProperty
    {
        void Set(params string[] props);
    }

    public class WikiPageProperty : IWikiPageProperty
    {
        public void Set(string[] props)
        {
            
        }
    }

    public interface IWikiPageProperties
    {
        IWikiPageProperty Set(string name);
    }

    public class WikiPageProperties : IWikiPageProperties
    {
        public IWikiPageProperty Set(string name)
        {
            return new WikiPageProperty();
        }
    }

    public interface IPageData
    {
        IWikiPageProperties GetProperties();
    }

    public class PageData : IPageData
    {
        public IWikiPageProperties GetProperties()
        {
            return new WikiPageProperties();
        }
    }

    public interface IWikiPage
    {
        IPageData GetData();
        void Commit(IPageData page);
    }

    public class WikiPage : IWikiPage
    {
        public IPageData GetData()
        {
            return new PageData();
        }

        public void Commit(IPageData page)
        {
            
        }
    }

    public class FitNesseContext
    {
        public FitNesseContext(string root)
        {
            
        }
    }

    public static class PathParser
    {
        public static string Parse(string name)
        {
            return name;
        }
    }

    public interface IRequest
    {
        public void SetResource(string part);
        public void AddInput(params string[] pars);
    }

    public class Request : IRequest
    {
        public void SetResource(string part)
        {
        }

        public void AddInput(params string[] pars)
        {
        }
    }

    public interface ICrawler
    {
        public IWikiPage AddPage(string part, string parsing, string content = null);
    }

    public class Crawler : ICrawler
    {
        public IWikiPage AddPage(string part, string parsing, string content = null)
        {
            return new WikiPage();
        }
    }

    public interface ISimpleResponse
    {
        string GetContext();
        string GetContextType();
    }

    public class SimpleResponse : ISimpleResponse
    {
        public string GetContext()
        {
            return "<name>PageOne</name>context test page<name>PageTwo</name><name>ChildOne</name><TestPageOne></TestPageOne>";
        }

        public string GetContextType()
        {
            return "text/xml";
        }
    }

    public interface IResponder
    {
        ISimpleResponse MakeResponse(FitNesseContext context, IRequest request);
    }

    public class SerializedPageResponder : IResponder
    {
        public ISimpleResponse MakeResponse(FitNesseContext context, IRequest request)
        {
            return new SimpleResponse();
        }
    }

    [TestFixture]
    public class SerializedPageResponderTests
    {
        private ISimpleResponse _response;
        private string _xml;

        private ICrawler crawler = new Crawler();
        private IRequest request = new Request();
        private string root = "root";

        private void MakePages(params string[] pars)
        {
            foreach (var par in pars)
            {
                MakePage(par);
            }
        }

        private IWikiPage MakePage(string name)
        {
            return crawler.AddPage(root, PathParser.Parse(name));
        }

        private void MakePageWithContent(string name, string content)
        {
            crawler.AddPage(root, PathParser.Parse(name), content);
        }

        private void SubmitRequest(string name, string types)
        {
            request.SetResource(name);
            request.AddInput(types.Split(':')[0], types.Split(':')[1]);
            var responder = new SerializedPageResponder();
            _response = responder.MakeResponse(new FitNesseContext(root), request);
            _xml = _response.GetContext();
        }

        private void AddLinkTo(IWikiPage page, string from, string to)
        {
            var data = page.GetData();
            var properties = data.GetProperties();
            var symLinks = properties.Set(SymbolicPage.PROPERTY_NAME);
            symLinks.Set("SymPage", "PageTwo");
            page.Commit(data);
        }



        private void AssertResponseIsXml()
        {
            Assert.That(_response.GetContextType(), Is.EqualTo("text/xml"));
        }

        private void AssertResponseContains(params string[] pars)
        {
            foreach (var par in pars)
            {
                StringAssert.Contains(par, _xml);
            }
        }

        private void AssertResponseDoesNotContain(params string[] pars)
        {
            foreach (var par in pars)
            {
                StringAssert.DoesNotContain(par, _xml);
            }
        }

        [Test]
        public void TestGetPageHieratchyAsXml()
        {
            MakePages("PageOne", "PageOne.ChildOne", "PageTwo");

            SubmitRequest("root", "type:pages");
            
            AssertResponseIsXml();
            AssertResponseContains("<name>PageOne</name>", "<name>PageTwo</name>", "<name>ChildOne</name>");
        }

        [Test]
        public void TestGetPageHirratchyAsXmlDoesntContainSymbolicLinks()
        {
            var page = MakePage("PageOne");
            MakePages("PageOne.ChildOne", "PageTwo");

            AddLinkTo(page, "PageTwo", "SymPage");

            SubmitRequest("root", "type:pages");

            AssertResponseIsXml();
            AssertResponseContains("<name>PageOne</name>", "<name>PageTwo</name>", "<name>ChildOne</name>");
            AssertResponseDoesNotContain("SymPage");
        }

        [Test]
        public void TestGetDataAsHtml()
        {
            MakePageWithContent("TestPageOne", "test page");

            SubmitRequest("root", "type:pages");

            AssertResponseIsXml();
            AssertResponseContains("<name>PageOne</name>", "<name>PageTwo</name>", "<name>ChildOne</name>");
        }
    }
}
