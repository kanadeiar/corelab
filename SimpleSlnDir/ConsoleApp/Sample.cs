namespace ConsoleApp
{
    public class Sample
    {
        public async Task<int> AddMethod(int value)
        {
            var val = value + 1;
            await Task.Delay(500);
            await Task.Delay(1000);
            return val;
        }
    }
}
