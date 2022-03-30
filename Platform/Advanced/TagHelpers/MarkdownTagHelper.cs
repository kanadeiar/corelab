using Microsoft.AspNetCore.Razor.TagHelpers;
using HeyRed.MarkdownSharp;

namespace Advanced.TagHelpers;

[HtmlTargetElement("p", Attributes = "markdown")]
public class MarkdownTagHelper : TagHelper
{
    public string Markdown { get; set; }
    public async override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        var options = new MarkdownOptions
        {
            AutoHyperlink = true,
            AutoNewLines = true,
            LinkEmails = true,
            QuoteSingleLine = true,
            StrictBoldItalic = true
        };
        Markdown mark = new Markdown(options);
        var html = mark.Transform(Markdown);
        output.Content.AppendHtml(html);
    }
}
