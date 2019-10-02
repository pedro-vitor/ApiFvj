using ApiFvj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiFvj.Data.VO
{
    public class LeadVO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LeadVO()
        {
            this.Comment = new HashSet<Comment>();
        }

        public int Id { get; set; }
        public int UsersId { get; set; }
        public string name { get; set; }
        public string numberphone { get; set; }
        public string desiredcourse { get; set; }
        public string town { get; set; }
        public string adress { get; set; }
        public string email { get; set; }
        public int active { get; set; }
        public System.DateTime createdat { get; set; }

        public virtual Users Users { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comment> Comment { get; set; }
    }
}