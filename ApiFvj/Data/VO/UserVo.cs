using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ApiFvj.Data.VO
{
    public class UserVO
    {
        public int Id { get; set; }
        public int ExternId { get; set; }

        [Required]
        [RegularExpression("[0-9]")]
        public string name { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 4)]
        public string password { get; set; }

        [Required]
        [Range(0, 1)]
        public int active { get; set; }

        public System.DateTime createdat { get; set; }
        public int Updated { get; set; }
    }
}