namespace FrameworkConsoleApp1.Models
{
    public class PersonControl
    {
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

        public PersonControl(Person person)
        {
            _person = person;
        }
    }
}