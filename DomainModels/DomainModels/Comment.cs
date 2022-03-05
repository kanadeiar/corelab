using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels
{
    public class Comment
    {
        [StringLength(200)]
        public string Description { get; set; }

        [Required, Range(1, int.MaxValue, ErrorMessage = "Должен быть выбран документ")]
        public int DocumentId { get; set; }
        [ForeignKey(nameof(DocumentId))]
        public Document Document { get; set; }
    }
}
