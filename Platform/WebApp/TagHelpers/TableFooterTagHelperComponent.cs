using Microsoft.AspNetCore.Mvc.Razor.TagHelpers;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace WebApp.TagHelpers;

[HtmlTargetElement("table")]
public class TableFooterSelector : TagHelperComponentTagHelper
{
    public TableFooterSelector(ITagHelperComponentManager manager, ILoggerFactory loggerFactory) : base(manager, loggerFactory)
    { }
}

public class TableFooterTagHelperComponent : TagHelperComponent
{
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        if (output.TagName == "table")
        {
            var cell = new TagBuilder("td");
            cell.Attributes.Add("colspan", "2");
            cell.Attributes.Add("class", "bg-dark text-white text-center");
            cell.InnerHtml.Append("Table footer");
            var row = new TagBuilder("tr");
            row.InnerHtml.AppendHtml(cell);
            var footer = new TagBuilder("tfoot");
            footer.InnerHtml.AppendHtml(row);
            output.PostContent.AppendHtml(footer);
        }
    }
}
