namespace ConsoleApp1.Tests.TDD;

[TestFixture]
public class MultiplicationTests
{
    [Test]
    public void TestSimpleAddition()
    {
        var five = Money.Dollar(5);
        var sum = five.Plus(five);
        var bank = new Bank();
        var reduced = bank.Reduce(sum, "USD");
        Assert.AreEqual(Money.Dollar(10), reduced);
    }

    [Test]
    public void MixedAdditionTest()
    {
        IExpression five = Money.Dollar(5);
        IExpression ten = Money.Franc(10);
        var bank = new Bank();
        bank.AddRate("CHF", "USD", 2);
        var result = bank.Reduce(five.Plus(ten), "USD");
        Assert.AreEqual(Money.Dollar(10), result);
    }

    [Test]
    public void TestPlusReturnsSum()
    {
        var five = Money.Dollar(5);
        var result = five.Plus(five);
        var sum = (Sum)result;
        Assert.AreEqual(five, sum.Augend);
        Assert.AreEqual(five, sum.Addend);
    }

    [Test]
    public void TestReduceSum()
    {
        var sum = new Sum(Money.Dollar(3), Money.Dollar(4));
        var bank = new Bank();
        var result = bank.Reduce(sum, "USD");
        Assert.AreEqual(Money.Dollar(7), result);
    }

    [Test]
    public void TestReduceMoney()
    {
        var bank = new Bank();
        var result = bank.Reduce(Money.Dollar(1), "USD");
        Assert.AreEqual(Money.Dollar(1), result);
    }

    [Test]
    public void TestIdentityRate()
    {
        Assert.AreEqual(1, new Bank().Rate("USD", "USD"));
    }

    [Test]
    public void TestReduceMoneyDifferentCurrency()
    {
        var bank = new Bank();
        bank.AddRate("CHF", "USD", 2);
        var result = bank.Reduce(Money.Franc(2), "USD");
        Assert.AreEqual(Money.Dollar(1), result);
    }

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
        Assert.IsFalse(Money.Franc(5).Equals(Money.Dollar(5)));
    }

    [Test]
    public void TestCurrency()
    {
        Assert.That(Money.Dollar(1).GetCurrency(), Is.EqualTo("USD"));
        Assert.That(Money.Franc(1).GetCurrency(), Is.EqualTo("CHF"));
    }
}