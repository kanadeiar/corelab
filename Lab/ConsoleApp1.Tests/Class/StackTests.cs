using ConsoleApp1.Class;

namespace ConsoleApp1.Tests.Class;

[TestFixture]
public class StackTests
{
    [Test]
    public void TestConstructor()
    {
        var expected = new int[] { 1, 2, 3 };

        var stack = new Stack(expected);

        var actuals = new List<int>();
        while (stack.GetSize() > 0)
        {
            actuals.Add(stack.Pop());
        }

        Assert.AreEqual(expected.Length, actuals.Count);
    }

    [Test]
    public void TestGetSize()
    {
        var stack = new Stack();

        var actual = stack.GetSize();
        Assert.AreEqual(0, actual);
        stack.Push(5);
        Assert.AreEqual(1, stack.GetSize());
    }

    [Test]
    public void TestPush()
    {
        var stack = new Stack();

        stack.Push(5);
        Assert.AreEqual(1, stack.GetSize());
        stack.Push(10);
        Assert.AreEqual(2, stack.GetSize());
        var actual = stack.Pop();
        Assert.AreEqual(10, actual);
        actual = stack.Pop();
        Assert.AreEqual(5, actual);
    }

    [Test]
    public void TestPop()
    {
        var stack = new Stack(new []{5});

        var actual = stack.Pop();

        Assert.AreEqual(5, actual);
    }

    [Test]
    public void TestPopError()
    {
        var stack = new Stack();

        Assert.Throws<ApplicationException>(() => stack.Pop());
    }
}