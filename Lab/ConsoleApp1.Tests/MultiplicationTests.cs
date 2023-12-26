using Moq;
using NuGet.Frameworks;

namespace ConsoleApp1.Tests;

[TestFixture]
public class MultiplicationTests
{
    [Test]
    public void TestMultiplication()
    {
        var five = Money.Dollar(5);
        Assert.That(five.Multiply(2), Is.EqualTo(Money.Dollar(10)));
        Assert.That(five.Multiply(3), Is.EqualTo(Money.Dollar(15)));
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

    [Test]
    public void TestCurrency()
    {
        Assert.That(Money.Dollar(1).GetCurrency(), Is.EqualTo("USD"));
        Assert.That(Money.Franc(1).GetCurrency(), Is.EqualTo("CHF"));
    }

    [Test]
    public void TestFrancMultiplication()
    {
        var five = Money.Franc(5);
        Assert.That(five.Multiply(2), Is.EqualTo(Money.Franc(10)));
        Assert.That(five.Multiply(3), Is.EqualTo(Money.Franc(15)));
    }
}