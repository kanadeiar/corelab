namespace ConsoleApp1.SenderModule.MessageFeat;

internal static class MessagesFactory
{
    public static Message Create(MessageCode code)
    {
        switch (code)
        {
            case MessageCode.Hello:
                return new HelloMessage();
            case MessageCode.Bye:
                return new ByeMessage();
            default:
                throw new IndexOutOfRangeException();
        }
    }
}