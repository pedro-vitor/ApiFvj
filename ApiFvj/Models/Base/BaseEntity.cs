using System.ComponentModel.DataAnnotations;

namespace ApiFvj.Models.Base
{
    public class BaseEntity
    {
        [Required]
        public int Id { get; set; }
    }
}