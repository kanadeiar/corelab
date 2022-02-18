namespace SportStore.Infrastructure;

[HtmlTargetElement("div", Attributes = "page-model")]
public class PageLinkTagHelper : TagHelper
{
    private IUrlHelperFactory urlHelperFactory;
    public PageLinkTagHelper(IUrlHelperFactory helperFactory)
    {
        urlHelperFactory = helperFactory;
    }
    [ViewContext]
    [HtmlAttributeNotBound]
    public ViewContext ViewContext { get; set; }
    public PagingInfoWebModel PageModel { get; set; }
    public string PageAction { get; set; }
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        var urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);
        var result = new TagBuilder("div");
        for (int i = 1; i <= PageModel.TotalPages; i++)
        {
            var tag = new TagBuilder("a");
            tag.Attributes["href"] = urlHelper.Action(PageAction, new { Page = i });
            tag.InnerHtml.Append(i.ToString());
            result.InnerHtml.AppendHtml(tag);
        }
        output.Content.AppendHtml(result.InnerHtml);
    }
}