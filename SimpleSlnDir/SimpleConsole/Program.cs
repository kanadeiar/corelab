using System.Reflection;
using System.Text;

namespace SimpleConsole;






internal class Program
{
    private static void Main(string[] args)
    {
        var parent = new Task(() =>
        {
            var cts = new CancellationTokenSource();
            var tf = new TaskFactory<int>(cts.Token, TaskCreationOptions.AttachedToParent, TaskContinuationOptions.ExecuteSynchronously, TaskScheduler.Default);
            var childs = new Task<int>[]
            {
                tf.StartNew(() => Sum(100, cts.Token)),
                tf.StartNew(() => Sum(200, cts.Token)),
                tf.StartNew(() => Sum(150, cts.Token)),
            };
            for (int i = 0; i < childs.Length; i++)
            {
                childs[i].ContinueWith(x => cts.Cancel(), TaskContinuationOptions.OnlyOnFaulted);
            }
            tf.ContinueWhenAll(childs, x => x.Where(t => !t.IsFaulted && !t.IsCanceled).Max(t => t.Result), CancellationToken.None)
            .ContinueWith(t => Console.WriteLine("Максимальное: {0}", t.Result), TaskContinuationOptions.ExecuteSynchronously);
        });
        parent.ContinueWith(p =>
        {
            var sb = new StringBuilder("Обнаружены исключения:" + Environment.NewLine);
            foreach (var e in p.Exception.Flatten().InnerExceptions)
                sb.AppendLine(" " + e.GetType().ToString());
            Console.WriteLine(sb.ToString());
        }, TaskContinuationOptions.OnlyOnFaulted);
        parent.Start();

        Console.WriteLine("Нажмите любую кнопку ...");
        var _ = Console.Read();
    }

    static int Sum(int values, CancellationToken? token = null)
    {
        var sum = 0;
        for (; values > 0; values--)
        {
            token?.ThrowIfCancellationRequested();
            sum += values;
        }
        return sum;
    }
}


