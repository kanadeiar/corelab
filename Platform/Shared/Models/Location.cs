using System.Collections.Generic;

namespace Shared.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public IEnumerable<Person> Persons { get; set; }
    }
}


