using System.Collections;

namespace ConsoleAppGaF.Behavior;

abstract class Iterator : IEnumerator
{
    object IEnumerator.Current => Current();
    public abstract int Key();
    public abstract object Current();
    public abstract bool MoveNext();
    public abstract void Reset();
}
abstract class IteratorAggregate : IEnumerable
{
    public abstract IEnumerator GetEnumerator();
}
class AlphabeticalOrderIterator : Iterator
{
    private WordsCollection _collection;
    private int _position = -1;
    private bool _reverse = false;
    public AlphabeticalOrderIterator(WordsCollection collection, bool reverse = false)
    {
        _collection = collection;
        _reverse = reverse;
        if (reverse)
        {
            _position = collection.getItems().Count;
        }
    }
    public override object Current()
    {
        return _collection.getItems()[_position];
    }
    public override int Key()
    {
        return _position;
    }
    public override bool MoveNext()
    {
        int updatedPosition = _position + (_reverse ? -1 : 1);

        if (updatedPosition >= 0 && updatedPosition < _collection.getItems().Count)
        {
            _position = updatedPosition;
            return true;
        }
        else
        {
            return false;
        }
    }
    public override void Reset()
    {
        _position = _reverse ? _collection.getItems().Count - 1 : 0;
    }
}
class WordsCollection : IteratorAggregate
{
    List<string> _collection = new List<string>();
    bool _direction = false;
    public void ReverseDirection()
    {
        _direction = !_direction;
    }
    public List<string> getItems()
    {
        return _collection;
    }
    public void Add(string item)
    {
        _collection.Add(item);
    }
    public override IEnumerator GetEnumerator()
    {
        return new AlphabeticalOrderIterator(this, _direction);
    }
}