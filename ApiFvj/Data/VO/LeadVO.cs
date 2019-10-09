using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ApiFvj.Data.VO
{
    public class LeadVO
    {
        public int Id { get; set; }
        public int ExternId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        [MaxLength(11)]
        public string numberphone { get; set; }

        [Required]
        public string desiredcourse { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 2)]
        public string town { get; set; }

        [Required]
        [StringLength(80, MinimumLength = 5)]
        public string address { get; set; }

        [Required]
        [EmailAddress]
        public string email { get; set; }

        [Required]
        [Range(0, 1)]
        public int active { get; set; }

        [Required]
        public System.DateTime createdat { get; set; }
        public int Updated { get; set; }
    }
}