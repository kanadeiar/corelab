using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace WebApp.TagHelpers;

public class TimeTagHelperComponent : TagHelperComponent
{
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        string timestamp = DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss");
        if (output.TagName == "body")
        {
            var elem = new TagBuilder("div");
            elem.Attributes.Add("class", "bg-info text-white m-2 p-2");
            elem.InnerHtml.Append($"Time: {timestamp}");
            output.PreContent.AppendHtml(elem);
        }
    }
}
