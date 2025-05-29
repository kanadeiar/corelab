namespace FrameworkConsoleApp1.Models.State
{
    public class OnlineState : ControlState
    {
        public override string Desctiption => "Онлайн";

        public OnlineState(PersonControl context) : base(context) 
        { }

        public override void Connect()
        {
            
        }

        public override void Disconnect()
        {
            StateSwitch.ToOffline();
        }
    }
}