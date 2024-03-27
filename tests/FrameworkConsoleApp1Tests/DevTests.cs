using AutoFixture.Xunit2;
using FluentAssertions;
using FrameworkConsoleApp1.Models;
using FrameworkConsoleApp1Tests.Infrastructure;
using Moq;
using Xunit;

namespace FrameworkConsoleApp1Tests
{
    public class DevTests
    {
        [Theory, AutoMoqData]
        public void TestMethod1([Frozen] Mock<IPerson> mock, Person person)
        {
            person.Name.Should().Be(person.Name);

            true.Should().Be(true);
        }
    }
}
