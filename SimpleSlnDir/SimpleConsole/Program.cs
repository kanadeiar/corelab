using System;
using System.Collections;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Text;

namespace CalculatorExamples;

[Serializable]
public abstract class ExceptionArgs
{
    public virtual string Message => string.Empty;
}
[Serializable]
public sealed class Exception<TArgs> : Exception, ISerializable where TArgs : ExceptionArgs
{
    private const string __args = "Args";
    private readonly TArgs _args;
    public TArgs Args => _args;
    public Exception(string message = null, Exception innerException = null)
    : this(null, message, innerException)
    { }
    public Exception(TArgs args, string message = null, Exception innerException = null)
    : base(message, innerException)
    {
        _args = args;
    }
    [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
    private Exception(SerializationInfo info, StreamingContext content) : base(info, content)
    {
        _args = (TArgs)info.GetValue(__args, typeof(TArgs));
    }
    [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
    public override void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        base.GetObjectData(info, context);
    }
    public override string Message
    {
        get
        {
            var s = base.Message;
            return (_args == null) ? s : s + " (" + _args.Message + ")";
        }
    }
    public override bool Equals(object? obj)
    {
        var other = obj as Exception<TArgs>;
        if (obj == null)
            return false;
        return object.Equals(_args, other._args) && base.Equals(obj);
    }
    public override int GetHashCode() => base.GetHashCode();
}

[Serializable]
public sealed class SampleExceptionArgs : ExceptionArgs
{
    private readonly string _message;
    public SampleExceptionArgs(string message)
    {
        _message = message;
    }
    public override String Message => _message;
}

internal class Program
{
    private static void Main(string[] args)
    {
        GCNotification.GCDone += x => Console.Beep();


        // try
        // {
        //     throw new Exception<SampleExceptionArgs>(new SampleExceptionArgs("Test"));
        // }
        // catch (Exception<SampleExceptionArgs> ex)
        // {
        //     Console.WriteLine(ex.Message + " " + ex.Args.Message);
        // }


        Console.WriteLine("Нажмите любую кнопку ...");
        var _ = Console.ReadLine();
    }
}


public static class GCNotification
{
    private static Action<int> _gcDone = null;
    public static event Action<int> GCDone
    {
        add
        {
            if (_gcDone is null)
            {
                new GenObject(0);
                new GenObject(2);
            }
            _gcDone += value;
        }
        remove => _gcDone -= value;
    }
    private sealed class GenObject
    {
        private int _generation;
        public GenObject(int generation)
        {
            _generation = generation;
        }
        ~GenObject()
        {
            Action<Int32> temp = Volatile.Read(ref _gcDone);
            if (temp != null)
                temp.Invoke(_generation);
            if ((_gcDone != null)
            && !AppDomain.CurrentDomain.IsFinalizingForUnload()
            && !Environment.HasShutdownStarted)
            {
                if (_generation == 0)
                    new GenObject(0);
                else
                    GC.ReRegisterForFinalize(this);
            }
            else
            { /* Позволяем объекту исчезнуть */ }

        }
    }
}







