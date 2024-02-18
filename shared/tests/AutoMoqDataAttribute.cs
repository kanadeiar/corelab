using AutoFixture;
using AutoFixture.AutoMoq;

namespace Kanadeiar.Tests;

public class AutoMoqDataAttribute : AutoDataAttribute
{
    public AutoMoqDataAttribute()
        : base(() => new Fixture()
            .Customize(new AutoMoqCustomization()))
    {
    }
}