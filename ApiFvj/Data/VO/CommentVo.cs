using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ApiFvj.Data.VO
{
    public class CommentVO
    {
        public int Id { get; set; }
        public int ExternId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int LeadId { get; set; }

        [Required]
        [StringLength(150, MinimumLength = 5)]
        public string text { get; set; }

        [Required]
        [Range(0, 1)]
        public int active { get; set; }

        [Required]
        public System.DateTime createdat { get; set; }
        public int Updated { get; set; }
    }
}