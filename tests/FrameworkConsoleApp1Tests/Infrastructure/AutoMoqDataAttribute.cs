using AutoFixture.Xunit2;
using AutoFixture;
using AutoFixture.AutoMoq;

namespace FrameworkConsoleApp1Tests.Infrastructure
{
    public class AutoMoqDataAttribute : AutoDataAttribute
    {
        public AutoMoqDataAttribute()
            : base(() => new Fixture()
                .Customize(new AutoMoqCustomization()))
        {
        }
    }
}
