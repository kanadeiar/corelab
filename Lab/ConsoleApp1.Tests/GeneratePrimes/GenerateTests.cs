using ConsoleApp1.GeneratePrimes;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace ConsoleApp1.Tests.GeneratePrimes;

[TestFixture]
public class GenerateTests
{
    [Test]
    public void GeneratePrimes_MaxValueIs1_ShouldEmptyResult()
    {
        var count = 1;

        var actual = Generate.GeneratePrimes(count);

        Assert.IsEmpty(actual);
    }

    [TestCase(2, new[] { 2 })]
    [TestCase(3, new[] { 2, 3 })]
    [TestCase(5, new[] { 2, 3, 5 })]
    [TestCase(10, new[] { 2, 3, 5, 7 })]
    [TestCase(20, new[] { 2, 3, 5, 7, 11, 13, 17, 19 })]
    [TestCase(30, new[] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29 })]
    public void GeneratePrimes_MaxValueIs2_ShouldCorrectResult(int count, int[] expected)
    {
        var actual = Generate.GeneratePrimes(count);

        Assert.That(actual, Is.EqualTo(expected));
    }
}