using DomainModels.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels
{
    public class Directory : Entity
    {
        [Required]
        [StringLength(200, MinimumLength = 3)]
        public string Name { get; set; }

        public int? BaseDirectoryId { get; set; }
        [ForeignKey(nameof(BaseDirectoryId))]
        public Directory BaseDirectory { get; set; }

        public int? BaseStorageId { get; set; }
        [ForeignKey(nameof(BaseStorageId))]
        public Storage BaseStorage { get; set; }

        public virtual IEnumerable<Document> Documents { get; set; } = new List<Document>();

        public virtual IEnumerable<Directory> Directorys { get; set; } = new List<Directory>();
    }
}
