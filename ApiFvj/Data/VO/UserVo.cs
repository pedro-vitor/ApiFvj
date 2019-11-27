using System.ComponentModel.DataAnnotations;

namespace ApiFvj.Data.VO
{
    public class UserVO
    {
        public int Id { get; set; }
        public int ExternId { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        [EmailAddress]
        public string email { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 4)]
        public string password { get; set; }

        [Required]
        [Range(0, 1)]
        public int active { get; set; }

        [Required]
        public System.DateTime createdat { get; set; }
        public int Updated { get; set; }

        public int Permission { get; set; }
    }
}