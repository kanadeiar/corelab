using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DomainModels
{
    public class Storage
    {
        [Required]
        [StringLength(200, MinimumLength = 3)]
        public string Name { get; set; }

        public virtual IEnumerable<Directory> Directorys { get; set; } = new List<Directory>();
    }
}
