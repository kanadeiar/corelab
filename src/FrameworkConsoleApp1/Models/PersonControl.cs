using FrameworkConsoleApp1.Models.State;

namespace FrameworkConsoleApp1.Models
{
    public class PersonControl
    {
        public ControlState State;

        private Person _person;
        
        public Person Person => _person;

        private Controller _controller;

        public Controller Controller
        {
            get => _controller;
            set
            {
                _controller?.friendControls.Remove(this);
                _controller = value;
                _controller?.friendControls.Add(this);
            }
        }

        public string Description => State.Desctiption;

        public PersonControl(Person person)
        {
            _person = person;
            State = StateSwitcher.Default(this);
        }

        public void Connect() => State.Connect();

        public void Disconnect() => State.Disconnect();
    }
}