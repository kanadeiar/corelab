namespace Wpf.Controls;

public partial class NumberControl : UserControl
{
    public static readonly DependencyProperty TitleProperty =
        DependencyProperty.Register("Title",
        typeof(string),
        typeof(NumberControl),
        new PropertyMetadata(default(string)));
    [Description("Заголовок")]
    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    public static readonly DependencyProperty CurrentNumberProperty =
        DependencyProperty.Register("CurrentNumber",
        typeof(int),
        typeof(NumberControl),
        new UIPropertyMetadata(0, new PropertyChangedCallback(CurrentNumberChanged)),
        new ValidateValueCallback(ValidateCurrentNumber));
    public static bool ValidateCurrentNumber(object value) =>
        Convert.ToInt32(value) >= 0 && Convert.ToInt32(value) <= 500;
    private static void CurrentNumberChanged(DependencyObject depObj,
        DependencyPropertyChangedEventArgs args)
    {
        var c = (NumberControl)depObj;
        var theLabel = c.LabelNumber;
        theLabel.Content = args.NewValue.ToString();
    }
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
