using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiFvj.Data.VO
{
    public class UserVO
    {
        public int Id { get; set; }
        public int ExternId { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public int active { get; set; }
        public System.DateTime createdat { get; set; }
        public int Updated { get; set; }
    }
}