using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiFvj.Data.VO
{
    public class CommentVO
    {
        public int Id { get; set; }
        public int ExternId { get; set; }
        public int UserId { get; set; }
        public int LeadId { get; set; }
        public string text { get; set; }
        public System.DateTime createdat { get; set; }
        public int Updated { get; set; }
    }
}