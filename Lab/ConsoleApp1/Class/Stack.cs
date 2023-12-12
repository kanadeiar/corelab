namespace ConsoleApp1.Class
{
    public class Stack(int[] items)
    {
        private int _count = items.Length;
        private IList<int> _items = Enumerable.ToList<int>(items);
        
        public Stack() : this(Array.Empty<int>()) { }

        public int GetSize()
        {
            return _count;
        }

        public void Push(int value)
        {
            _count++;
            _items.Add(value);
        }

        public int Pop()
        {
            if (_count == 0)
            {
                throw new ApplicationException();
            }
            int element = _items[--_count];
            _items.RemoveAt(_count);
            return element;
        }
    }
}
