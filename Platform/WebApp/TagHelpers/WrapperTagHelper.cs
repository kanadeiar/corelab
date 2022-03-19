using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace WebApp.TagHelpers;

[HtmlTargetElement("*", Attributes = "[wrapper=true]")]
public class ContentWrapperTagHelper : TagHelper
{
    public bool Wrapper { get; set; }
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        var elem = new TagBuilder("div");
        elem.Attributes["class"] = "bg-primary text-white p-2 m-2";
        elem.InnerHtml.AppendHtml("Wrapper");
        output.PreElement.AppendHtml(elem);
        output.PostElement.AppendHtml(elem);
    }
}
