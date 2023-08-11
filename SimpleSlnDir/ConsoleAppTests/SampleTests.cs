using ConsoleApp;

namespace ConsoleAppTests
{
    public class SampleTests
    {
        [Fact]
        public async Task GetPage_Correct_ShouldBeOk()
        {
            var x = await Sample.GetPage(@"https://ya.ru");
            var len = x.Length;
            Assert.NotEqual(0, len);
        }
    }
}