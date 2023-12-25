using NuGet.Frameworks;

namespace ConsoleApp1.Tests;

[TestFixture]
public class MultiplicationTests
{
    [Test]
    public void TestMultiplication()
    {
        var five = Money.Dollar(5);
        Assert.AreEqual(Money.Dollar(10), five.Multiply(2));
        Assert.AreEqual(Money.Dollar(15), five.Multiply(3));
    }

    [Test]
    public void TestEquality()
    {
        Assert.IsTrue(Money.Dollar(5).Equals(Money.Dollar(5)));
        Assert.IsFalse(Money.Dollar(5).Equals(Money.Dollar(6)));
        Assert.IsTrue(Money.Franc(5).Equals(Money.Franc(5)));
        Assert.IsFalse(Money.Franc(5).Equals(Money.Franc(6)));
        Assert.IsFalse(Money.Franc(5).Equals(Money.Dollar(5)));
    }

    //[Test]
    //public void TestFrancMultiplication()
    //{
    //    var five = new Franc(5);
    //    Assert.AreEqual(Money.Franc(10), five.Multiply(2));
    //    Assert.AreEqual(Money.Franc(15), five.Multiply(3));
    //}
}