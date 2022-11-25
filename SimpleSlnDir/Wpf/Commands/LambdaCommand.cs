namespace Wpf.Commands;

/// <summary>
/// Быстроиспользуемая команда
/// </summary>
public class LambdaCommand : Base.BaseCommand
{
    private readonly Action<object> _Execute;
    private readonly Func<object, bool>? _CanExecute;
    protected LambdaCommand() { _Execute = default!; }
    public LambdaCommand(Action<object> execute, Func<object, bool>? canExecute = null)
    {
        _Execute = execute ?? throw new ArgumentNullException(nameof(execute));
        _CanExecute = canExecute;
    }

    protected override bool CanExecute(object? p) => _CanExecute?.Invoke(p!) ?? true;
    protected override void Execute(object? p) => _Execute.Invoke(p!);
}

/// <summary>
/// Быстроиспользуемая команда
/// </summary>
public class LambdaCommand<T> : LambdaCommand
{
    private readonly Action<T> _Execute;
    private readonly Func<T, bool>? _CanExecute;
    public LambdaCommand(Action<T> execute, Func<T, bool>? canExecute = null)
    {
        _Execute = execute ?? throw new ArgumentNullException(nameof(execute));
        _CanExecute = canExecute;
    }
    protected override bool CanExecute(object? p) => _CanExecute?.Invoke((T)p!) ?? true;
    protected override void Execute(object? p) => _Execute.Invoke((T)p!);
}