using System.ComponentModel.DataAnnotations;

namespace DomainModels.Base
{
    public abstract class Entity
    {
        [Key]
        public int Id { get; set; }
    }
}
