using System.Collections.Generic;
using System.Linq;

namespace FrameworkConsoleApp1.Models
{
    public class Controller
    {
        private HashSet<PersonControl> _controls = new HashSet<PersonControl>();

        public IEnumerable<Person> GetPersons => _controls.Select(x => x.Person);

        /// <summary> Должен использоваться только в PersonControl </summary>
        internal HashSet<PersonControl> friendControls => _controls;

        public void AddPersonControl(PersonControl control) => control.Controller = this;

        public void RemovePersonControl(PersonControl control) => control.Controller = null;
    }
}
