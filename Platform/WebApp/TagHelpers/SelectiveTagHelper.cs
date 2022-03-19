using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace WebApp.TagHelpers;

[HtmlTargetElement("div", Attributes = "max-product-id, for")]
public class SelectiveTagHelper : TagHelper
{
    public int MaxProductId { get; set; }
    public ModelExpression For { get; set; }
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        if (For.Model.GetType() == typeof(int) && (int)For.Model < MaxProductId)
        {
            output.SuppressOutput();
        }
    }
}
