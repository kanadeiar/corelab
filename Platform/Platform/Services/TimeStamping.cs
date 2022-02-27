namespace Platform.Services;

public class DefaultTimeStamper : ITimeStamper
{
    public string TimeStamp => DateTime.Now.ToShortTimeString();
}

public interface ITimeStamper
{
    string TimeStamp { get; }
}
