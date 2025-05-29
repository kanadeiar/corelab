namespace FrameworkConsoleApp1.Models.State
{
    public class StateSwitcher
    {
        private readonly PersonControl _context;
        
        public StateSwitcher(PersonControl context)
        {
            _context = context;
        }

        public static ControlState Default(PersonControl context) => new OfflineState(context);
        
        public void ToOffline() => _context.State = new OfflineState(_context);

        public void ToOnline() => _context.State = new OnlineState(_context);
    }
}