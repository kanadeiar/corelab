namespace CalculatorExamples;

public static class ToolsExtensions
{
    public static void Raise<TEArgs>(this TEArgs e, object sender, ref EventHandler<TEArgs> eventDelegate)
    {
        if (Volatile.Read(ref eventDelegate) is { } temp)
        {
            temp.Invoke(sender, e);
        }
    }

    public static T? GetValueFromPrivateField<T>(this object obj, string name)
    {
        var fieldInfo = obj.GetType().GetField(name, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        var result = (T?)fieldInfo?.GetValue(obj);
        return result;
    }
}