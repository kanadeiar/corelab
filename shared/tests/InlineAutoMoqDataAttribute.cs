using Kanadeiar.Tests;

namespace FrameworkConsoleApp1Tests.Infrastructure
{
    public class InlineAutoMoqDataAttribute : InlineAutoDataAttribute
    {
        public InlineAutoMoqDataAttribute(params object[] objects)
            : base(new AutoMoqDataAttribute(), objects) { }
    }
}
