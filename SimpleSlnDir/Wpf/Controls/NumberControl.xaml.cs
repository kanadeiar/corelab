namespace Wpf.Controls;

public partial class NumberControl : UserControl
{
    public static readonly DependencyProperty CurrentNumberProperty =
        DependencyProperty.Register("CurrentNumber",
        typeof(int),
        typeof(NumberControl),
        new UIPropertyMetadata(0, new PropertyChangedCallback(CurrentNumberChanged), new CoerceValueCallback(CoerceCurrentNumber)), new ValidateValueCallback(ValidateCurrentNumber));
    private static void CurrentNumberChanged(DependencyObject depObj,
        DependencyPropertyChangedEventArgs args)
    {
        var c = (NumberControl)depObj;
        var theLabel = c.LabelNumber;
        theLabel.Content = args.NewValue.ToString();
    }
    private static object CoerceCurrentNumber(DependencyObject d, object value)
    {
        var baseVal = (NumberControl)d;
        if ((int)value < default(int))
        {
            return default(int);
        }
        if ((int)value > 1000)
        {
            return 1000;
        }
        return value;
    }
    public static bool ValidateCurrentNumber(object value) =>
        Convert.ToInt32(value) >= 0 && Convert.ToInt32(value) <= 9000;
    [Description("Текущий номер")]
    public int CurrentNumber
    {
        get => (int)GetValue(CurrentNumberProperty);
        set => SetValue(CurrentNumberProperty, value);
    }
    public NumberControl()
    {
        InitializeComponent();
    }
}
