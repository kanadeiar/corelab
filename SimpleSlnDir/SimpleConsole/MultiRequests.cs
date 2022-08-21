namespace SimpleConsole
{
    public class MultiRequests
    {
        static async Task<string> ConcatAsync(string s1, string s2)
        {
            var result = string.Concat(s1, s2);
            await Task.Delay(1_000);
            return result;
        }
        private AsyncCoordinator _ac = new AsyncCoordinator();
        private IDictionary<string, object?> _names = new Dictionary<string, object?> {
            { "Иван", null },
            { "Сидор", null },
            { "Петр", null },
            { "Петр1", null },
            { "Петр2", null },
            { "Петр3", null },
            { "Петр4", null },
            { "Петр5", null },
        };
        public MultiRequests(int timeout = Timeout.Infinite)
        {
            var adding = "Главный ";
            foreach (var name in _names.Keys)
            {
                _ac.AboutToBegin(1);
                ConcatAsync(adding, name)
                    .ContinueWith(task => ComputeResult(name, task));
                _ac.AllBegun(AllDone, timeout);
            }
        }
        private void ComputeResult(string name, Task<string> task)
        {
            object result;
            if (task.Exception != null)
            {
                result = task.Exception.InnerException!;
            }
            else
            {
                result = task.Result;
            }
            // Сохранение результата (исключение/измененное имя) и обозначение одной завершенной операции
            _names[name] = result;
            _ac.JustEnded();
        }
        public void Cancel() { _ac.Cancel(); }
        private void AllDone(CoordinationStatus status)
        {
            switch (status)
            {
                case CoordinationStatus.Cancel:
                    Console.WriteLine("Операция отменена.");
                    break;
                case CoordinationStatus.Timeout:
                    Console.WriteLine("Время на выполнение истекло.");
                    break;
                case CoordinationStatus.AllDone:
                    Console.WriteLine("Операция выполнена, ее результаты:");
                    foreach (var keyPair in _names)
                    {
                        object? result = keyPair.Value;
                        if (result is Exception ex)
                        {
                            Console.WriteLine("{0} ошибка: {1}", keyPair.Key, ex.GetType().Name);
                        }
                        else
                        {
                            Console.WriteLine("{0} результат: {1}", keyPair.Key, result);
                        }
                    }
                    break;
            }
        }
    }
}