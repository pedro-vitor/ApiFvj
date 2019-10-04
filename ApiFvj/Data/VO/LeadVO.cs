using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiFvj.Data.VO
{
    public class LeadVO
    {
        public int Id { get; set; }
        public int ExternId { get; set; }
        public int UserId { get; set; }
        public string name { get; set; }
        public string numberphone { get; set; }
        public string desiredcourse { get; set; }
        public string town { get; set; }
        public string address { get; set; }
        public string email { get; set; }
        public int active { get; set; }
        public System.DateTime createdat { get; set; }
        public int Updated { get; set; }
    }
}