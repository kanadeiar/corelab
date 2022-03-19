using Microsoft.AspNetCore.Razor.TagHelpers;

namespace WebApp.TagHelpers;

[HtmlTargetElement("*", Attributes = "[highlight]")]
public class HighlightTagHelper : TagHelper
{
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.PreContent.SetHtmlContent("<b><i>");
        output.PostContent.SetHtmlContent("</i></b>");
    }
}
