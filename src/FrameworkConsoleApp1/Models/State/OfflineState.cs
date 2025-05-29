namespace FrameworkConsoleApp1.Models.State
{
    public class OfflineState : ControlState
    {
        public override string Desctiption => "Оффлайн";

        public OfflineState(PersonControl context) : base(context)
        { }

        public override void Connect()
        {
            StateSwitch.ToOnline();
        }

        public override void Disconnect()
        {
            
        }
    }
}