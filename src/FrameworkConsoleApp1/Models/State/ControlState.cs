namespace FrameworkConsoleApp1.Models.State
{
    public abstract class ControlState
    {
        private PersonControl _context;

        protected PersonControl Context => _context;

        public StateSwitcher StateSwitch { get; private set; }

        public abstract string Desctiption { get; }

        public ControlState(PersonControl context)
        { 
            _context = context;
            StateSwitch = new StateSwitcher(_context);
        }

        public abstract void Connect();

        public abstract void Disconnect();
    }
}