namespace SimpleConsole;



internal class Program
{
    private static void Main(string[] args)
    {
        unsafe
        {
            int val = 2;
            Square(&val);
            Console.WriteLine(val);
        }


        Console.WriteLine("Нажмите любую кнопку ...");
        var v = Console.Read();

        static unsafe void Square(int* pointer)
        {
            *pointer *= *pointer;
        }
    }
}

unsafe struct NodeVal
{
    public int Value;
    public NodeVal* Next;
}