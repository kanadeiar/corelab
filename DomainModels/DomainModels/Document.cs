using DomainModels.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainModels
{
    public class Document : Entity
    {
        [Required]
        public DateTime Created { get; set; } = DateTime.Now;

        [Required]
        [StringLength(200, MinimumLength = 3)]
        public string Name { get; set; }

        [StringLength(200)]
        public string Description { get; set; }

        [StringLength(200)]
        public string Note { get; set; }

        [StringLength(200)]
        public string Author { get; set; }

        [Required, Range(1, int.MaxValue)]
        public int DirectoryId { get; set; }
        [ForeignKey(nameof(DirectoryId))]
        public Directory Directory { get; set; }
    }
}
