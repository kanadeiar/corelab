namespace WinFormsApp1;

public class Interval : FormNotifyBase
{
    private int _start;
    private int _end;
    private int _length;

    public int Start
    {
        get => _start;
        set
        {
            if (Set(ref _start, value))
            {
                calculateLength();
            }
        }
    }

    public int End
    {
        get => _end;
        set
        {
            if (Set(ref _end, value))
            {
                calculateLength();
            }
        }
    }

    public int Length
    {
        get => _length;
        set
        {
            if (Set(ref _length, value))
            {
                calculateEnd();
            }
        }
    }

    private void calculateLength()
    {
        var length = End - Start;
        Length = length;
    }

    private void calculateEnd()
    {
        var end = Start + Length;
        End = end;
    }
}